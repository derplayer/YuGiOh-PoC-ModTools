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
    public partial class ValueUserControl : UserControl
    {
        private YuGiValue _value;

        public YuGiValue Value
        {
            get { return _value; }
            set
            {
                _value = value;
                UpdateBinding();
            }
        }

        public ValueUserControl()
        {
            InitializeComponent();
        }

        private void UpdateBinding()
        {

        }
    }
}
