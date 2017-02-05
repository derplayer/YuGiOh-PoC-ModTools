using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace YuGiOh_PoC_Patcher
{
    public partial class BasicSettings : Form
    {
        public List<Tuple<string, bool>> settingList = new List<Tuple<string, bool>>();

        public BasicSettings()
        {
            InitializeComponent();
        }

        private void BasicSettings_Load(object sender, EventArgs e)
        {
            comboBox_Language.Items.Add("Spanish");
            comboBox_Language.Items.Add("Italian");
            comboBox_Language.Items.Add("French");
            comboBox_Language.Items.Add("German");
            comboBox_Language.Items.Add("English");
            comboBox_Language.Items.Add("Japanese");

            RegistryKey checkSettings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\YuGiOhModLauncher\\v1\\", true);

            foreach (var item in checkSettings.GetValueNames())
            {

                foreach (var CheckBoxItem in Controls.OfType<GroupBox>().SelectMany(groupBox => groupBox.Controls.OfType<CheckBox>()))
                {
                    if (CheckBoxItem.Text == item)
                    {
                        CheckBoxItem.Checked = Convert.ToBoolean(checkSettings.GetValue(item));
                    }
                }

                foreach (var RadioButtonItem in Controls.OfType<GroupBox>().SelectMany(groupBox => groupBox.Controls.OfType<RadioButton>()))
                {
                    if (RadioButtonItem.Text == item)
                    {
                        RadioButtonItem.Checked = Convert.ToBoolean(checkSettings.GetValue(item));
                    }
                }

                if ("Language" == item)
                    comboBox_Language.SelectedItem = checkSettings.GetValue(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var CheckBoxItem in Controls.OfType<GroupBox>().SelectMany(groupBox => groupBox.Controls.OfType<CheckBox>()))
            {
                settingList.Add(new Tuple<string, bool>(CheckBoxItem.Text, CheckBoxItem.Checked));
            }

            foreach (var RadioButtonItem in Controls.OfType<GroupBox>().SelectMany(groupBox => groupBox.Controls.OfType<RadioButton>()))
            {
                settingList.Add(new Tuple<string, bool>(RadioButtonItem.Text, RadioButtonItem.Checked));
            }

            //Check
            //RegistryKey checkSettings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\YuGiOhModLauncher\\v1\\", true);

            //Create Default Registry Values when it dosent Exist
            //if (checkSettings != null)
            //{
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

                key.CreateSubKey("YuGiOhModLauncher");
                key = key.OpenSubKey("YuGiOhModLauncher", true);

                key.CreateSubKey("v1");
                key = key.OpenSubKey("v1", true);


                foreach (var item in settingList)
                {
                key.SetValue(item.Item1, item.Item2);
                }
                //Lang
                key.SetValue("Language", comboBox_Language.SelectedItem);
            
                this.Close();
                //string serialized = JsonConvert.SerializeObject(YuGiOh_Version.versionJSON);

            //}
        }

        private void groupBox_Graphic_Enter(object sender, EventArgs e)
        {

        }
    }
}
