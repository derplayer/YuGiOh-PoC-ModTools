using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using YuGiOh_PoC_Patcher.YuGi;
using YuGiOh_PoC_Patcher.YuGi.Values;

namespace YuGiOh_PoC_Patcher
{
    public partial class PointUserControl : UserControl
    {
        private YuGiPoint _point;
        public YuGiPoint Point
        {
            get { return _point; }
            set
            {
                _point = value;
                if (_point != null) UpdateBinding();
            }
        }

        public PointUserControl()
        {
            InitializeComponent();

        }

        private void UpdateBinding()
        {
            groupBox.Text = Point.Name;
            valueUserControl_X.Value = Point.X;
            valueUserControl_Y.Value = Point.Y;
        }

    }
}
