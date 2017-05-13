using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuGiOh_PoC_Patcher
{
    public partial class DebugPatchWindow : Form
    {
        public DebugPatchWindow()
        {
            InitializeComponent();
        }

        private void timer_Progress_Tick(object sender, EventArgs e)
        {
            switch (label_Progress.Text)
            {
                case "Patching Values":
                    label_Progress.Text = "Patching Values.";
                    break;
                case "Patching Values.":
                    label_Progress.Text = "Patching Values..";
                    break;
                case "Patching Values..":
                    label_Progress.Text = "Patching Values...";
                    break;
                case "Patching Values...":
                    label_Progress.Text = "Patching Values";
                    break;
            }
            
        }
    }
}
