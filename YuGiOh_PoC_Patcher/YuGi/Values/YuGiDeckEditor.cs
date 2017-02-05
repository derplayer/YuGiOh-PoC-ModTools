using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiDeckEditor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public YuGiPoint CardListScrollBar { get; set; } = new YuGiPoint("CardList ScrollBar Offset", new YuGiValue("CardList ScrollBar Offset X", 0x0006E2EE, BitConverter.GetBytes(775)), new YuGiValue("CardList ScrollBar Offset Y", 0x0006E2F5, BitConverter.GetBytes(50)));
        public YuGiPoint CardListScrollBarBackground { get; set; } = new YuGiPoint("CardList ScrollBar Background Offset", new YuGiValue("CardList ScrollBar Background Offset X", 0x0006E071, BitConverter.GetBytes(767)), new YuGiValue("CardList ScrollBar Background Offset Y", 0x0006E06B, new byte[]{ 0x00 }));
        public YuGiValue CardListScrollBarLength { get; set; } = new YuGiValue("CardList ScrollBar Length", 0x0006E2C9, BitConverter.GetBytes(626));


        [XmlIgnore]
        public byte CardListCardSpacing
        {
            get { return CardListCardSpacingValues.Value[0]; }
            set
            {
                CardListCardSpacingValues.Value = BitConverter.GetBytes(value);
                
                CardListCardSpacingElementSymbolsMax.ValueInt32 = value * CardListCardCount;
                OnPropertyChanged("CardListCardSpacing");
            }
        }

        [XmlIgnore]
        public int CardListCardCount
        {
            get { return BitConverter.ToInt32(CardListCardCountValues.Value, 0); }
            set
            {
                CardListCardCountValues.Value = BitConverter.GetBytes(value);

                CardListCardSpacingElementSymbolsMax.ValueInt32 = CardListCardSpacing * value;
                OnPropertyChanged("CardListCardCount");
            }
        }

        public YuGiValueList CardListCardCountValues { get; set; } = new YuGiValueList
        {
            new YuGiValue("CardList CardCount CardImage", 0x0006D705, BitConverter.GetBytes(10)),
            new YuGiValue("CardList CardCount Text/Element/ATK/DFS", 0x0006DD76, BitConverter.GetBytes(10)),
            new YuGiValue("CardList CardCount CountText/BannedSymbol", 0x0006E0B3, BitConverter.GetBytes(10))
        };

        public YuGiValueList CardListCardSpacingValues { get; set; } = new YuGiValueList
        {
            new YuGiValue("CardList CardSpacing CardImage", 0x00066A42, new byte[] { 0x37 }),
            new YuGiValue("CardList CardSpacing ElementSymbols", 0x0006C609, new byte[] { 0x37 }),
            new YuGiValue("CardList Closed CardSpacing ATK/DFS", 0x0006DD22, new byte[] { 0x37 }),
            new YuGiValue("CardList CardSpacing CardText", 0x0006DF30, new byte[] { 0x37 }),
            new YuGiValue("CardList CardSpacing CountText", 0x0006E10E, new byte[] { 0x37 })
        };

        public YuGiValue CardListCardSpacingElementSymbolsMax { get; set; } = new YuGiValue("CardList CardSpacing ElementSymbols Max", 0x0006C612, BitConverter.GetBytes(550));


        public YuGiRectangle DeckZone { get; set; } = new YuGiRectangle
        {
            Name = "DeckZone",
            Left = new YuGiValue("DeckZone Left", 0x001DB660, BitConverter.GetBytes(262)),
            Top = new YuGiValue("DeckZone Top", 0x001DB664, BitConverter.GetBytes(23)),
            Right = new YuGiValue("DeckZone Right", 0x001DB668, BitConverter.GetBytes(670)),
            Bottom = new YuGiValue("DeckZone Bottom", 0x001DB66C, BitConverter.GetBytes(379))
        };

        public YuGiRectangle SideDeckZone { get; set; } = new YuGiRectangle
        {
            Name = "SideDeckZone",
            Left = new YuGiValue("SideDeckZone Left", 0x001DB670, BitConverter.GetBytes(262)),
            Top = new YuGiValue("SideDeckZone Top", 0x001DB674, BitConverter.GetBytes(412)),
            Right = new YuGiValue("SideDeckZone Right", 0x001DB678, BitConverter.GetBytes(670)),
            Bottom = new YuGiValue("SideDeckZone Bottom", 0x001DB67C, BitConverter.GetBytes(512))
        };

        public YuGiRectangle FusionDeckZone { get; set; } = new YuGiRectangle
        {
            Name = "FusionDeckZone",
            Left = new YuGiValue("FusionDeckZone Left", 0x001DB680, BitConverter.GetBytes(262)),
            Top = new YuGiValue("FusionDeckZone Top", 0x001DB684, BitConverter.GetBytes(515)),
            Right = new YuGiValue("FusionDeckZone Right", 0x001DB688, BitConverter.GetBytes(670)),
            Bottom = new YuGiValue("FusionDeckZone Bottom", 0x001DB68C, BitConverter.GetBytes(616))
        };


        public YuGiDeckEditor()
        {
            DeckZone.PropertyChanged += ValueChanged;
            SideDeckZone.PropertyChanged += ValueChanged;
            FusionDeckZone.PropertyChanged += ValueChanged;
            CardListCardCountValues.PropertyChanged += ValueChanged;
            CardListCardSpacingValues.PropertyChanged += ValueChanged;

            CardListScrollBar.PropertyChanged += ValueChanged;
            CardListScrollBarBackground.PropertyChanged += ValueChanged;
            CardListScrollBarLength.PropertyChanged += ValueChanged;
        }

        public void CopyValues(YuGiDeckEditor deckEditor)
        {
            DeckZone.CopyValues(deckEditor.DeckZone);
            SideDeckZone.CopyValues(deckEditor.SideDeckZone);
            FusionDeckZone.CopyValues(deckEditor.FusionDeckZone);
            CardListCardCountValues.CopyValues(deckEditor.CardListCardCountValues);
            CardListCardSpacingValues.CopyValues(deckEditor.CardListCardSpacingValues);

            CardListScrollBar.CopyValues(deckEditor.CardListScrollBar);
            CardListScrollBarBackground.CopyValues(deckEditor.CardListScrollBarBackground);
            CardListScrollBarLength.ValueInt32 = deckEditor.CardListScrollBarLength.ValueInt32;
        }

        public void LoadValue(BinaryReader reader, bool update = false)
        {
            DeckZone.LoadValue(reader, update);
            SideDeckZone.LoadValue(reader, update);
            FusionDeckZone.LoadValue(reader, update);
            CardListCardCountValues.LoadValue(reader, update);
            CardListCardSpacingValues.LoadValue(reader, update);

            CardListScrollBar.LoadValue(reader, update);
            CardListScrollBarBackground.LoadValue(reader, update);
            CardListScrollBarLength.LoadValue(reader, update);
        }

        public void PatchValue(BinaryWriter writer)
        {
            DeckZone.PatchValue(writer);
            SideDeckZone.PatchValue(writer);
            FusionDeckZone.PatchValue(writer);
            CardListCardCountValues.PatchValue(writer);
            CardListCardSpacingValues.PatchValue(writer);

            CardListScrollBar.PatchValue(writer);
            CardListScrollBarBackground.PatchValue(writer);
            CardListScrollBarLength.PatchValue(writer);
        }

        public void PatchDefault(BinaryWriter writer)
        {
            DeckZone.PatchDefault(writer);
            SideDeckZone.PatchDefault(writer);
            FusionDeckZone.PatchDefault(writer);
            CardListCardCountValues.PatchDefault(writer);
            CardListCardSpacingValues.PatchDefault(writer);

            CardListScrollBar.PatchDefault(writer);
            CardListScrollBarBackground.PatchDefault(writer);
            CardListScrollBarLength.PatchDefault(writer);
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
