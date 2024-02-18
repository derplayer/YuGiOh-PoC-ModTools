using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace YuGiOh_PoC_Patcher.UserControls
{
    public partial class FindBox : Form
    {
       // public string SearchString;
        public CardSearchParams searchParams;

        public FindBox()
        {
            InitializeComponent();
            searchParams = new CardSearchParams();
            searchParams.bSearchCardID = true;
            searchParams.bSearchName = true;
        }

        void SaveCheckboxes()
        {
            searchParams.bSearchCardID = checkBoxCardID.Checked;
            searchParams.bSearchName = checkBoxName.Checked;
            searchParams.bSearchDescription = checkBoxDescription.Checked;
            searchParams.bSearchKind = checkBoxKind.Checked;
            searchParams.bSearchLevel = checkBoxLevel.Checked;
            searchParams.bSearchATK = checkBoxATK.Checked;
            searchParams.bSearchDEF = checkBoxDEF.Checked;
            searchParams.bSearchType = checkBoxType.Checked;
            searchParams.bSearchAttr = checkBoxAttr.Checked;
            searchParams.bSearchIcon = checkBoxIcon.Checked;
            searchParams.bSearchRarity = checkBoxRarity.Checked;
            searchParams.bSearchPassword = checkBoxPass.Checked;
            searchParams.bSearchCardExists = checkBoxExists.Checked;

            searchParams.bMatchWhole = checkBoxMatch.Checked;
            searchParams.bMatchCase = checkBoxCase.Checked;
        }

        void LoadCheckboxes()
        {
            checkBoxCardID.Checked = searchParams.bSearchCardID;
            checkBoxName.Checked = searchParams.bSearchName;
            checkBoxDescription.Checked = searchParams.bSearchDescription;
            checkBoxKind.Checked = searchParams.bSearchKind;
            checkBoxLevel.Checked = searchParams.bSearchLevel;
            checkBoxATK.Checked = searchParams.bSearchATK;
            checkBoxDEF.Checked = searchParams.bSearchDEF;
            checkBoxType.Checked = searchParams.bSearchType;
            checkBoxAttr.Checked = searchParams.bSearchAttr;
            checkBoxIcon.Checked = searchParams.bSearchIcon;
            checkBoxRarity.Checked = searchParams.bSearchRarity;
            checkBoxPass.Checked = searchParams.bSearchPassword;
            checkBoxExists.Checked = searchParams.bSearchCardExists;
            checkBoxMatch.Checked = searchParams.bMatchWhole;
            checkBoxCase.Checked = searchParams.bMatchCase;
        }


        private void FindBox_Load(object sender, EventArgs e)
        {
            textBox1.Text = searchParams.SearchString;

            LoadCheckboxes();

            // start pos at the corner of the parent window
            Location = new Point(Owner.Location.X + 40, Owner.Location.Y + 40);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveCheckboxes();

            DialogResult = DialogResult.Cancel;
            Close();
        }

        bool IsAnyBoxTicked()
        {
            return checkBoxCardID.Checked 
                || checkBoxName.Checked
                || checkBoxDescription.Checked
                || checkBoxKind.Checked
                || checkBoxLevel.Checked
                || checkBoxATK.Checked
                || checkBoxDEF.Checked
                || checkBoxType.Checked
                || checkBoxAttr.Checked
                || checkBoxIcon.Checked
                || checkBoxRarity.Checked
                || checkBoxPass.Checked
                || checkBoxExists.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || !IsAnyBoxTicked())
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveCheckboxes();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchParams.SearchString = textBox1.Text;
        }

        private void FindBox_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
