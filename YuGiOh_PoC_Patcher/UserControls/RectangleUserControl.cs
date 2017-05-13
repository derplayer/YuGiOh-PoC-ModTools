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
    public partial class RectangleUserControl : UserControl
    {
        private YuGiRectangle _rectangle;
        public YuGiRectangle Rectangle
        {
            get { return _rectangle; }
            set
            {
                _rectangle = value;
                if (_rectangle != null) UpdateBinding();
            }
        }

        public RectangleUserControl()
        {
            InitializeComponent();
        }


        private void UpdateBinding()
        {
            groupBox.Text = Rectangle.Name;
            valueUserControl_Left.Value = Rectangle.Left;
            valueUserControl_Top.Value = Rectangle.Top;
            valueUserControl_Right.Value = Rectangle.Right;
            valueUserControl_Bottom.Value = Rectangle.Bottom;
        }

    }
}
