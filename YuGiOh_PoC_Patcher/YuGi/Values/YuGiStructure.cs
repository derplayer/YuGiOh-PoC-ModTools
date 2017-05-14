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

        public YuGiPoint WindowSizeOffset { get; set; } = new YuGiPoint("WindowSize",
            new YuGiValue("Window Width (DDraw)", 0x00011369, BitConverter.GetBytes(800))
            {
                Children =
                {
                    new YuGiValue("DuelField Window Width 1", 0x00024C8A, BitConverter.GetBytes(800), true),
                    new YuGiValue("DuelField Window Width 2", 0x00024CCE, BitConverter.GetBytes(800), true),
                    new YuGiValue("Rect Fix Width", 0x0003E54D, BitConverter.GetBytes(800), true),
                    new YuGiValue("Effect Activator End Point Top Right Corner", 0x00024D65, BitConverter.GetBytes(800), true),
                    new YuGiValue("Effect Activator End Point Mid Right Corner", 0x00024D9B, BitConverter.GetBytes(800), true)
                }
            },
            new YuGiValue("Window Height (DDraw)", 0x00011361, BitConverter.GetBytes(600))
            {
                Children =
                {
                    new YuGiValue("DuelField Window Height 1", 0x00024C85, BitConverter.GetBytes(600), true),
                    new YuGiValue("DuelField Window Height 2", 0x00024CC9, BitConverter.GetBytes(600), true),
                    new YuGiValue("Rect Fix Height", 0x0003E579, BitConverter.GetBytes(600), true),
                    new YuGiValue("Effect Activator End Point Down Right Corner", 0x00024DA3, BitConverter.GetBytes(600), true),
                    new YuGiValue("Choose Zone (Deck Fix)", 0x0001E849, BitConverter.GetBytes(600), true)
                }
            });

        public YuGiDuelField DuelField { get; set; } = new YuGiDuelField();
        public YuGiDeckEditor DeckEditor { get; set; } = new YuGiDeckEditor();

        public YuGiStructure()
        {
            CardSize = new PointEx(50, 72);

            CardSize.PropertyChanged += ValueChanged;
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
            WindowSizeOffset.LoadValues(reader, update);
            DuelField.LoadValues(reader, update);
            DeckEditor.LoadValues(reader, update);
        }

        public void PatchValue(BinaryWriter writer)
        {
            WindowSizeOffset.PatchValues(writer);
            DuelField.PatchValues(writer);
            DeckEditor.PatchValues(writer);
        }

        public void PatchDefault(BinaryWriter writer)
        {
            WindowSizeOffset.PatchDefault(writer);
            DuelField.PatchDefault(writer);
            DeckEditor.PatchDefault(writer);
        }

        public void DebugPatchValues()
        {
            WindowSizeOffset.DebugPatchValues();
            DuelField.DebugPatchValues();
            DeckEditor.DebugPatchValues();
        }

        private void ValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
