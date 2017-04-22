using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using YuGiOh_PoC_Patcher.YuGi.Values;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiStructure : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _rotate;
        private PointEx _windowSize;
        private PointEx _cardSize;

        public bool Rotate
        {
            get { return _rotate; }
            set
            {
                _rotate = value;
                OnPropertyChanged("Rotate");
            }
        }
        public PointEx WindowSize
        {
            get { return _windowSize; }
            set
            {
                _windowSize = value;
                OnPropertyChanged("WindowSize");
                if (value == null) return;
                _windowSize.PropertyChanged += ValueChanged;
            }
        }
        public PointEx CardSize
        {
            get { return _cardSize; }
            set
            {
                _cardSize = value;
                OnPropertyChanged("CardSize");
                if (value == null) return;
                _cardSize.PropertyChanged += ValueChanged;
               
            }
        }

        public YuGiDuelField DuelField { get; set; } = new YuGiDuelField();
        public YuGiDeckEditor DeckEditor { get; set; } = new YuGiDeckEditor();
        public YuGiPoint WindowSizeOffset { get; set; } = new YuGiPoint("WindowSize (DDraw)", new YuGiValue("Window Width", 0x00011369, BitConverter.GetBytes(800)), new YuGiValue("Window Height", 0x00011361, BitConverter.GetBytes(600)));

        public YuGiStructure()
        {
            CardSize = new PointEx(50, 72);

            WindowSizeOffset.PropertyChanged += ValueChanged;
            DuelField.PropertyChanged += ValueChanged;
            DeckEditor.PropertyChanged += ValueChanged;
        }

        public void CopyValues(YuGiStructure structure)
        {
            Rotate = structure.Rotate;
            CardSize.X = structure.CardSize.X;
            CardSize.Y = structure.CardSize.Y;

            WindowSizeOffset.CopyValues(structure.WindowSizeOffset);
            DuelField.CopyValues(structure.DuelField);
            DeckEditor.CopyValues(structure.DeckEditor);
        }


        public void LoadValue(BinaryReader reader, bool update = false)
        {
            WindowSizeOffset.LoadValue(reader, update);
            DuelField.LoadValue(reader, update);
            DeckEditor.LoadValue(reader, update);
        }

        public void PatchSingleValue(BinaryWriter Writer, int Offset, byte[] Value, int Length)
        {
            Writer.Seek(Offset, SeekOrigin.Begin);
            Writer.Write(Value, 0, Length);
        }

        public void PatchValue(BinaryWriter writer)
        {
            WindowSizeOffset.PatchValue(writer);
            DuelField.PatchValue(writer);
            DeckEditor.PatchValue(writer);

            //Patch over the Masterpatch
            YuGiPoint masterPatch1 = new YuGiPoint("Duel Crashfix", new YuGiValue("Duel Crashfix1 Width", 0x00024C85, WindowSizeOffset.Y.Value), new YuGiValue("Duel Crashfix1 Height", 0x00024C8A, WindowSizeOffset.X.Value));
            YuGiPoint masterPatch11 = new YuGiPoint("Duel Crashfix", new YuGiValue("Duel Crashfix2 Width", 0x00024CC9, WindowSizeOffset.Y.Value), new YuGiValue("Duel Crashfix2 Height", 0x00024CCE, WindowSizeOffset.X.Value));
            YuGiPoint masterPatch2 = new YuGiPoint("Rect Fix", new YuGiValue("Rect Fix Width", 0x0003E54D, WindowSizeOffset.X.Value), new YuGiValue("Rect Fix Height", 0x0003E579, WindowSizeOffset.Y.Value));

            masterPatch1.PatchValue(writer);
            masterPatch11.PatchValue(writer);
            masterPatch2.PatchValue(writer);
            PatchSingleValue(writer, 0x00024D65, WindowSizeOffset.X.Value, WindowSizeOffset.X.Length); //Effect Activator End Point for Top Right Corner
            PatchSingleValue(writer, 0x00024D9B, WindowSizeOffset.X.Value, WindowSizeOffset.X.Length); //Effect Activator End Point for Mid Right Corner
            PatchSingleValue(writer, 0x00024DA3, WindowSizeOffset.Y.Value, WindowSizeOffset.Y.Length); //Effect Activator End Point for Down Right Corner

            PatchSingleValue(writer, 0x0001E849, WindowSizeOffset.Y.Value, WindowSizeOffset.Y.Length); //Patch for Choose Zone (Deck Fix)
        }

        public void PatchDefault(BinaryWriter writer)
        {
            WindowSizeOffset.PatchDefault(writer);
            DuelField.PatchDefault(writer);
            DeckEditor.PatchDefault(writer);
        }

        private void ValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (propertyName != "Value") return; //draw fix heh
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
