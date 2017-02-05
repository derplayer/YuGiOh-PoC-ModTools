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
                UpdateBinding();
            }
        }

        public PointBundleUserControl()
        {
            InitializeComponent();
        }


        private void UpdateBinding()
        {
            numericUpDown_X.DataBindings.Clear();
            numericUpDown_Y.DataBindings.Clear();
            numericUpDown_Gap.DataBindings.Clear();

            if (PointBundle == null) return;

            //textBox1.DataBindings.Clear();
            //textBox1.MaxLength = Point.Y.Length * 2;
            //textBox1.DataBindings.Add("Text", Point.Y, "ValueAscii", true, DataSourceUpdateMode.OnPropertyChanged);

            double length = Math.Pow(2, PointBundle.Points[0].X.Length * 8);
            numericUpDown_X.Maximum = (decimal)length / 2 - 1;
            numericUpDown_X.Minimum = (decimal)length / 2 * -1;

            length = Math.Pow(2, PointBundle.Points[0].Y.Length * 8);
            numericUpDown_Y.Maximum = (decimal)length / 2 - 1;
            numericUpDown_Y.Minimum = (decimal)length / 2 * -1;

            groupBox.Text = PointBundle.Name;
            numericUpDown_X.DataBindings.Add("Value", PointBundle.Points[0].X, "ValueInt32", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown_Y.DataBindings.Add("Value", PointBundle.Points[0].Y, "ValueInt32", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown_Gap.DataBindings.Add("Value", PointBundle, "Gap", true, DataSourceUpdateMode.OnPropertyChanged);
        }

    }
}
