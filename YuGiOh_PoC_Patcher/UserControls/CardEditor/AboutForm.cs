using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuGiOh_PoC_Patcher.UserControls
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xan1242");
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Version: " + ProductVersion;

            Location = new Point(Owner.Location.X + (Owner.Size.Width / 2) - (Width / 2), Owner.Location.Y + (Owner.Size.Height / 2) - (Height / 2));
        }
    }
}
