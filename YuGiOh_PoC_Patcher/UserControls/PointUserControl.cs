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
                UpdateBinding();
            }
        }

        public PointUserControl()
        {
            InitializeComponent();
        }

        private void UpdateBinding()
        {
            numericUpDown_X.DataBindings.Clear();
            numericUpDown_Y.DataBindings.Clear();

            if (Point == null) return;

            //textBox1.DataBindings.Clear();
            //textBox1.MaxLength = Point.Y.Length * 2;
            //textBox1.DataBindings.Add("Text", Point.Y, "ValueAscii", true, DataSourceUpdateMode.OnPropertyChanged);

            double length = Math.Pow(2, Point.X.Length * 8);
            numericUpDown_X.Maximum = (decimal)length / 2 - 1;
            numericUpDown_X.Minimum = (decimal)length / 2 * -1;

            length = Math.Pow(2, Point.Y.Length * 8);
            numericUpDown_Y.Maximum = (decimal)length / 2 - 1;
            numericUpDown_Y.Minimum = (decimal)length / 2 * -1;

            groupBox.Text = Point.Name;
            numericUpDown_X.DataBindings.Add("Value", Point.X, "ValueInt32", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown_Y.DataBindings.Add("Value", Point.Y, "ValueInt32", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    }
}
