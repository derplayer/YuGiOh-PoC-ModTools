using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    /// <summary>
    /// All the YuGiNodes/YuGiValues for the Duel Field
    /// </summary>
    public class YuGiDuelField : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public YuGiNode RootNode = new YuGiNode("DuelField")
        {
            Children =
            {
                new YuGiNode("PlayerField")
                {
                    Children =
                    {
                        new YuGiPoint("Deck", new YuGiValue("Player Deck Offset X", 0x001DB5B0, BitConverter.GetBytes(760)), new YuGiValue("Player Deck Offset Y", 0x001DB5B4, BitConverter.GetBytes(460))),
                        new YuGiPoint("Graveyard", new YuGiValue("Player Graveyard Offset X", 0x001DB5C0, BitConverter.GetBytes(760)), new YuGiValue("Player Graveyard Offset Y", 0x001DB5C4, BitConverter.GetBytes(366))),
                        new YuGiPoint("Fusion", new YuGiValue("Player Fusion Offset X", 0x001DB5D0, BitConverter.GetBytes(284)), new YuGiValue("Player Fusion Offset Y", 0x001DB5D4, BitConverter.GetBytes(460))),
                        new YuGiPoint("Field Effect Card", new YuGiValue("Player FieldEffect Offset X", 0x001DB5E0, BitConverter.GetBytes(286)), new YuGiValue("Player FieldEffect Offset Y", 0x001DB5E4, BitConverter.GetBytes(353))),
                        new YuGiPoint("Hand", new YuGiValue("Player Hand Offset X", 0x001DB608, BitConverter.GetBytes(525)), new YuGiValue("Player Hand Offset Y", 0x001DB60C, BitConverter.GetBytes(600))),
                        new YuGiPoint("Removed From Game", new YuGiValue("Player RemovedFromGame Offset X", 0x001DB5F0, BitConverter.GetBytes(762)), new YuGiValue("Player RemovedFromGame Offset Y", 0x001DB5F4, BitConverter.GetBytes(308))),
                        new YuGiPointBundle("Spell/Trap Cards", 78)
                        {
                            Children =
                            {
                                new YuGiPoint("Magic Card 1", new YuGiValue("Player Magic Card 1 Offset X", 0x001DB510, BitConverter.GetBytes(369)), new YuGiValue("Player Magic Card 1 Offset Y", 0x001DB514, BitConverter.GetBytes(460))),
                                new YuGiPoint("Magic Card 2", new YuGiValue("Player Magic Card 2 Offset X", 0x001DB518, BitConverter.GetBytes(447)), new YuGiValue("Player Magic Card 2 Offset Y", 0x001DB51C, BitConverter.GetBytes(460))),
                                new YuGiPoint("Magic Card 3", new YuGiValue("Player Magic Card 3 Offset X", 0x001DB520, BitConverter.GetBytes(525)), new YuGiValue("Player Magic Card 3 Offset Y", 0x001DB524, BitConverter.GetBytes(460))),
                                new YuGiPoint("Magic Card 4", new YuGiValue("Player Magic Card 4 Offset X", 0x001DB528, BitConverter.GetBytes(603)), new YuGiValue("Player Magic Card 4 Offset Y", 0x001DB52C, BitConverter.GetBytes(460))),
                                new YuGiPoint("Magic Card 5", new YuGiValue("Player Magic Card 5 Offset X", 0x001DB530, BitConverter.GetBytes(681)), new YuGiValue("Player Magic Card 5 Offset Y", 0x001DB534, BitConverter.GetBytes(460)))
                            }
                        },
                        new YuGiPointBundle("Monster Cards", 78)
                        {
                            Children =
                            {
                                new YuGiPoint("Monster Card 1", new YuGiValue("Player Monster Card 1 Offset X", 0x001DB560, BitConverter.GetBytes(369)), new YuGiValue("Player Monster Card 1 Offset Y", 0x001DB564, BitConverter.GetBytes(352))),
                                new YuGiPoint("Monster Card 2", new YuGiValue("Player Monster Card 2 Offset X", 0x001DB568, BitConverter.GetBytes(447)), new YuGiValue("Player Monster Card 2 Offset Y", 0x001DB56C, BitConverter.GetBytes(352))),
                                new YuGiPoint("Monster Card 3", new YuGiValue("Player Monster Card 3 Offset X", 0x001DB570, BitConverter.GetBytes(525)), new YuGiValue("Player Monster Card 3 Offset Y", 0x001DB574, BitConverter.GetBytes(352))),
                                new YuGiPoint("Monster Card 4", new YuGiValue("Player Monster Card 4 Offset X", 0x001DB578, BitConverter.GetBytes(603)), new YuGiValue("Player Monster Card 4 Offset Y", 0x001DB57C, BitConverter.GetBytes(352))),
                                new YuGiPoint("Monster Card 5", new YuGiValue("Player Monster Card 5 Offset X", 0x001DB580, BitConverter.GetBytes(681)), new YuGiValue("Player Monster Card 5 Offset Y", 0x001DB584, BitConverter.GetBytes(352)))
                            }
                        }
                    }
                },
                new YuGiNode("EnemyField")
                {
                    Children =
                    {
                        new YuGiPoint("Deck", new YuGiValue("Enemy Deck Offset X", 0x001DB5B8, BitConverter.GetBytes(290)), new YuGiValue("Enemy Deck Offset Y", 0x001DB5BC, BitConverter.GetBytes(140))),
                        new YuGiPoint("Graveyard", new YuGiValue("Enemy Graveyard Offset X", 0x001DB5C8, BitConverter.GetBytes(290)), new YuGiValue("Enemy Graveyard Offset Y", 0x001DB5CC, BitConverter.GetBytes(234))),
                        new YuGiPoint("Fusion", new YuGiValue("Enemy Fusion Offset X", 0x001DB5D8, BitConverter.GetBytes(766)), new YuGiValue("Enemy Fusion Offset Y", 0x001DB5DC, BitConverter.GetBytes(140))),
                        new YuGiPoint("Field Effect Card", new YuGiValue("Enemy FieldEffect Offset X", 0x001DB5E8, BitConverter.GetBytes(766)), new YuGiValue("Enemy FieldEffect Offset Y", 0x001DB5EC, BitConverter.GetBytes(236))),
                        new YuGiPoint("Hand", new YuGiValue("Enemy Hand Offset X", 0x001DB610, BitConverter.GetBytes(525)), new YuGiValue("Enemy Hand Offset Y", 0x001DB614, BitConverter.GetBytes(0))),
                        new YuGiPoint("Removed From Game", new YuGiValue("Enemy RemovedFromGame Offset X", 0x001DB5F8, BitConverter.GetBytes(292)), new YuGiValue("Enemy RemovedFromGame Offset Y", 0x001DB5FC, BitConverter.GetBytes(292))),
                        new YuGiPointBundle("Spell/Trap Cards", 78)
                        {
                            Children =
                            {
                                new YuGiPoint("Magic Card 1", new YuGiValue("Enemy Magic Card 1 Offset X", 0x001DB558, BitConverter.GetBytes(369)), new YuGiValue("Enemy Magic Card 1 Offset Y", 0x001DB55C, BitConverter.GetBytes(140))),
                                new YuGiPoint("Magic Card 2", new YuGiValue("Enemy Magic Card 2 Offset X", 0x001DB550, BitConverter.GetBytes(447)), new YuGiValue("Enemy Magic Card 2 Offset Y", 0x001DB554, BitConverter.GetBytes(140))),
                                new YuGiPoint("Magic Card 3", new YuGiValue("Enemy Magic Card 3 Offset X", 0x001DB548, BitConverter.GetBytes(525)), new YuGiValue("Enemy Magic Card 3 Offset Y", 0x001DB54C, BitConverter.GetBytes(140))),
                                new YuGiPoint("Magic Card 4", new YuGiValue("Enemy Magic Card 4 Offset X", 0x001DB540, BitConverter.GetBytes(603)), new YuGiValue("Enemy Magic Card 4 Offset Y", 0x001DB544, BitConverter.GetBytes(140))),
                                new YuGiPoint("Magic Card 5", new YuGiValue("Enemy Magic Card 5 Offset X", 0x001DB538, BitConverter.GetBytes(681)), new YuGiValue("Enemy Magic Card 5 Offset Y", 0x001DB53C, BitConverter.GetBytes(140)))
                            }
                        },
                        new YuGiPointBundle("Monster Cards", 78)
                        {
                            Children =
                            {
                                new YuGiPoint("Monster Card 1", new YuGiValue("Enemy Monster Card 1 Offset X", 0x001DB5A8, BitConverter.GetBytes(369)), new YuGiValue("Enemy Monster Card 1 Offset Y", 0x001DB5AC, BitConverter.GetBytes(248))),
                                new YuGiPoint("Monster Card 2", new YuGiValue("Enemy Monster Card 2 Offset X", 0x001DB5A0, BitConverter.GetBytes(447)), new YuGiValue("Enemy Monster Card 2 Offset Y", 0x001DB5A4, BitConverter.GetBytes(248))),
                                new YuGiPoint("Monster Card 3", new YuGiValue("Enemy Monster Card 3 Offset X", 0x001DB598, BitConverter.GetBytes(525)), new YuGiValue("Enemy Monster Card 3 Offset Y", 0x001DB59C, BitConverter.GetBytes(248))),
                                new YuGiPoint("Monster Card 4", new YuGiValue("Enemy Monster Card 4 Offset X", 0x001DB590, BitConverter.GetBytes(603)), new YuGiValue("Enemy Monster Card 4 Offset Y", 0x001DB594, BitConverter.GetBytes(248))),
                                new YuGiPoint("Monster Card 5", new YuGiValue("Enemy Monster Card 5 Offset X", 0x001DB588, BitConverter.GetBytes(681)), new YuGiValue("Enemy Monster Card 5 Offset Y", 0x001DB58C, BitConverter.GetBytes(248)))
                            }
                        }
                    }
                }
            }
        };

       
        public YuGiDuelField()
        {
            RootNode.PropertyChanged += ValueChanged;
        }

        public void CopyValues(YuGiDuelField duelField)
        {
            RootNode.CopyValues(duelField.RootNode);
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
