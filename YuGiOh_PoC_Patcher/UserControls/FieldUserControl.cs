using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh_PoC_Patcher.YuGi;
using YuGiOh_PoC_Patcher.YuGi.Values;

namespace YuGiOh_PoC_Patcher
{
    public partial class FieldUserControl : UserControl
    {
        private YuGiField _field;

        public YuGiField Field
        {
            get { return _field; }
            set
            {
                _field = value;
                UpdateBinding();
            }
        }

        public FieldUserControl()
        {
            InitializeComponent();
        }

        private void UpdateBinding()
        {
            if (Field == null) return;

            pointUserControl_Hand.Point = Field.HandOffset;
            pointUserControl_RemovedFromGame.Point = Field.RemovedFromGameOffset;
            pointUserControl_Deck.Point = Field.DeckOffset;
            pointUserControl_Graveyard.Point = Field.GraveyardOffset;
            pointUserControl_Fusion.Point = Field.FusionOffset;
            pointUserControl_FieldEffect.Point = Field.FieldEffectOffset;

            pointBundleUserControl_MonsterCards.PointBundle = Field.MonsterCards;
            pointBundleUserControl_MagicCards.PointBundle = Field.MagicCards;
        }
    }
}
