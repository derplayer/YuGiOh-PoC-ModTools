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

namespace YuGiOh_PoC_Patcher.UserControls
{
    public partial class PointBundleUserControl : UserControl
    {
        private YuGiPointBundle _pointBundle;
        public YuGiPointBundle PointBundle
        {
            get { return _pointBundle; }
            set
            {
                _pointBundle = value;
                if (_pointBundle != null) UpdateBinding();
            }
        }

        public PointBundleUserControl()
        {
            InitializeComponent();
        }


        private void UpdateBinding()
        {
            groupBox.Text = PointBundle.Name;
            valueUserControl_X.Value = ((YuGiPoint)PointBundle.Children[0]).X;
            valueUserControl_Y.Value = ((YuGiPoint)PointBundle.Children[0]).Y;
            numericUpDown_Gap.Value = PointBundle.Gap;
        }

        private void numericUpDown_Gap_ValueChanged(object sender, EventArgs e)
        {
            PointBundle.Gap = (int)numericUpDown_Gap.Value;
        }
    }
}
