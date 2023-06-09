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
    /// <summary>
    /// All the YuGiNodes/YuGiValues for the Deck Editor
    /// TODO: v1.0 offsets and official exe offsets...!
    /// </summary>
    public class YuGiDeckEditor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static YuGiValue CardListCardSpacingElementSymbolsMax = new YuGiValue("CardList CardSpacing ElementSymbols Max", 0x0006C612, BitConverter.GetBytes(550), true);
        public static YuGiValue CardListCardSpacingElementSymbols = new YuGiValue("CardList CardSpacing ElementSymbols", 0x0006C609, new byte[] { 0x37 }, CardSpacingCountValueChanged);
        public static YuGiValue CardListCardCountTextElementATKDFS = new YuGiValue("CardList CardCount Text/Element/ATK/DFS", 0x0006DD76, BitConverter.GetBytes(10), CardSpacingCountValueChanged);

        public YuGiNode RootNode = new YuGiNode("DeckEditor")
        {
            Children =
            {
                new YuGiNode("CardList")
                {
                    Children =
                    {
                        new YuGiNode("ScrollBar")
                        {
                            Children =
                            {
                                new YuGiPoint("CardList ScrollBar Offset", new YuGiValue("CardList ScrollBar Offset X", 0x0006E2EE, BitConverter.GetBytes(775)), new YuGiValue("CardList ScrollBar Offset Y", 0x0006E2F5, BitConverter.GetBytes(50))),
                                new YuGiPoint("CardList ScrollBar Background Offset", new YuGiValue("CardList ScrollBar Background Offset X", 0x0006E071, BitConverter.GetBytes(767)), new YuGiValue("CardList ScrollBar Background Offset Y", 0x0006E06B, new byte[]{ 0x00 })),
                                new YuGiValue("CardList ScrollBar Length", 0x0006E2C9, BitConverter.GetBytes(626))
                            }
                        },
                        new YuGiValueList("CardSpacing")
                        {
                            Children =
                            {
                                new YuGiValue("CardList CardSpacing CardImage", 0x00066A42, new byte[] { 0x37 }, true),
                                CardListCardSpacingElementSymbols,
                                new YuGiValue("CardList Closed CardSpacing ATK/DFS", 0x0006DD22, new byte[] { 0x37 }, true),
                                new YuGiValue("CardList CardSpacing CardText", 0x0006DF30, new byte[] { 0x37 }, true),
                                new YuGiValue("CardList CardSpacing CountText", 0x0006E10E, new byte[] { 0x37 }, true),
                            }
                        },
                        new YuGiValueList("CardCount")
                        {
                            Children =
                            {
                                new YuGiValue("CardList CardCount CardImage", 0x0006D705, BitConverter.GetBytes(10), true),
                                CardListCardCountTextElementATKDFS,
                                new YuGiValue("CardList CardCount CountText/BannedSymbol", 0x0006E0B3, BitConverter.GetBytes(10), true)
                            }
                        },
                        new YuGiValueList("Calculated Values")
                        {
                            Children =
                            {
                                CardListCardSpacingElementSymbolsMax
                            }
                        }
                    }
                },
                new YuGiNode("Deck")
                {
                    Children =
                    {
                        new YuGiRectangle("Deck Zone", new YuGiValue("Deck Zone Left", 0x001DB660, BitConverter.GetBytes(262)), new YuGiValue("Deck Zone Top", 0x001DB664, BitConverter.GetBytes(23)), new YuGiValue("Deck Zone Right", 0x001DB668, BitConverter.GetBytes(670)), new YuGiValue("Deck Zone Bottom", 0x001DB66C, BitConverter.GetBytes(379))),
                        new YuGiValue("Deck Zone Horizontal Card Spacing", 0x000664FB, new byte[] { 0x0A })
                    }
                },
                new YuGiNode("SideDeck")
                {
                    Children =
                    {
                        new YuGiRectangle("SideDeck Zone", new YuGiValue("SideDeck Zone Left", 0x001DB670, BitConverter.GetBytes(262)), new YuGiValue("SideDeck Zone Top", 0x001DB674, BitConverter.GetBytes(412)), new YuGiValue("SideDeck Zone Right", 0x001DB678, BitConverter.GetBytes(670)), new YuGiValue("SideDeck Zone Bottom", 0x001DB67C, BitConverter.GetBytes(512))),
                        new YuGiValue("SideDeck Zone Horizontal Card Spacing", 0x00066519, new byte[] { 0x0A })
                    }
                },
                new YuGiNode("FusionDeck")
                {
                    Children =
                    {
                        new YuGiRectangle("FusionDeck Zone", new YuGiValue("FusionDeckFusionDeck Zone Left", 0x001DB680, BitConverter.GetBytes(262)), new YuGiValue("FusionDeck Zone Top", 0x001DB684, BitConverter.GetBytes(515)), new YuGiValue("FusionDeck Zone Right", 0x001DB688, BitConverter.GetBytes(670)), new YuGiValue("FusionDeck Zone Bottom", 0x001DB68C, BitConverter.GetBytes(616))),
                        new YuGiValue("FusionDeck Zone Horizontal Card Spacing", 0x0006654A, new byte[] { 0x0A })
                    }
                }
            }
        };



        public YuGiDeckEditor()
        {
            RootNode.PropertyChanged += ValueChanged;
        }

        public void CopyValues(YuGiDeckEditor deckEditor)
        {
            RootNode.CopyValues(deckEditor.RootNode);
        }
        public void LoadValues(BinaryReader reader, bool update = false)
        {
            RootNode.LoadValues(reader, update);
        }

        public void PatchValues(BinaryWriter writer)
        {
            RootNode.PatchValues(writer);
        }

        public void PatchDefault(BinaryWriter writer)
        {
            RootNode.PatchDefault(writer);
        }

        public void DebugPatchValues()
        {
            RootNode.DebugPatchValues();
        }

        private static void CardSpacingCountValueChanged(object sender, PropertyChangedEventArgs e)
        {
            CardListCardSpacingElementSymbolsMax.ValueInt32 = CardListCardSpacingElementSymbols.ValueUInt8 * CardListCardCountTextElementATKDFS.ValueInt32;
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
