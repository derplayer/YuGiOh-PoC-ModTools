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
    public partial class ReplaceBox : Form
    {
        public CardSearchParams searchParams; // this needs to be defined outside because we're using Show() to display this dialog, and when it's closed it purges it from memory...
        FormCardEdit form1;
        bool bSetNumericAcceptors = false;
        bool bInComboBoxMode = false;
        bool bStringMatchWholeLastState = false;

        public ReplaceBox(CardSearchParams inSearchParams, FormCardEdit inForm1)
        {
            InitializeComponent();
            //searchParams = new CardSearchParams();

            searchParams = inSearchParams;
            form1 = inForm1;
        }

        void SaveCheckboxes()
        {
            searchParams.bSearchDescription =   radioButtonDescription.Checked;
            searchParams.bSearchName =          radioButtonName.Checked;
            searchParams.bSearchKind =          radioButtonKind.Checked;
            searchParams.bSearchLevel =         radioButtonLevel.Checked;
            searchParams.bSearchATK =           radioButtonATK.Checked;
            searchParams.bSearchDEF =           radioButtonDEF.Checked;
            searchParams.bSearchType =          radioButtonType.Checked;
            searchParams.bSearchAttr =          radioButtonAttr.Checked;
            searchParams.bSearchIcon =          radioButtonIcon.Checked;
            searchParams.bSearchRarity =        radioButtonRarity.Checked;
            searchParams.bSearchPassword =      radioButtonPassword.Checked;
            searchParams.bSearchCardExists =    radioButtonCardExists.Checked;

            searchParams.bMatchWhole = checkBoxMatch.Checked;
            searchParams.bMatchCase = checkBoxCase.Checked;
        }

        void LoadCheckboxes()
        {
            radioButtonDescription.Checked = searchParams.bSearchDescription;
            radioButtonName.Checked = searchParams.bSearchName;
            radioButtonKind.Checked = searchParams.bSearchKind;
            radioButtonLevel.Checked = searchParams.bSearchLevel;
            radioButtonATK.Checked = searchParams.bSearchATK;
            radioButtonDEF.Checked = searchParams.bSearchDEF;
            radioButtonType.Checked = searchParams.bSearchType;
            radioButtonAttr.Checked = searchParams.bSearchAttr;
            radioButtonIcon.Checked = searchParams.bSearchIcon;
            radioButtonRarity.Checked = searchParams.bSearchRarity;
            radioButtonPassword.Checked = searchParams.bSearchPassword;
            radioButtonCardExists.Checked = searchParams.bSearchCardExists;

            checkBoxMatch.Checked = searchParams.bMatchWhole;
            checkBoxCase.Checked = searchParams.bMatchCase;
        }

        bool IsANumericBoxTicked()
        {
            return radioButtonLevel.Checked
                || radioButtonATK.Checked
                || radioButtonDEF.Checked
                || radioButtonPassword.Checked;
        }

        void SetSearchContext() // since there can only be one for replace action, we can define it here
        {
            if (radioButtonName.Checked)
                searchParams.SearchContext = CardProps.Name;
            if (radioButtonDescription.Checked)
                searchParams.SearchContext = CardProps.Description;
            if (radioButtonKind.Checked)
                searchParams.SearchContext = CardProps.Kind;
            if (radioButtonLevel.Checked)
                searchParams.SearchContext = CardProps.Level;
            if (radioButtonATK.Checked)
                searchParams.SearchContext = CardProps.ATK;
            if (radioButtonDEF.Checked)
                searchParams.SearchContext = CardProps.DEF;
            if (radioButtonType.Checked)
                searchParams.SearchContext = CardProps.Type;
            if (radioButtonAttr.Checked)
                searchParams.SearchContext = CardProps.Attr;
            if (radioButtonIcon.Checked)
                searchParams.SearchContext = CardProps.Icon;
            if (radioButtonRarity.Checked)
                searchParams.SearchContext = CardProps.Rarity;
            if (radioButtonPassword.Checked)
                searchParams.SearchContext = CardProps.Password;
            if (radioButtonCardExists.Checked)
                searchParams.SearchContext = CardProps.CardExists;
        }

        private bool Int32TextAcceptor(string oldText, string newText, string input, int offset, int length)
        {
            int value = 0;
            return Int32.TryParse(newText, out value); ;
        }

        void SetAcceptors()
        {
            fastTextBoxFind.TextAcceptor = Int32TextAcceptor;
            fastTextBoxReplace.TextAcceptor = Int32TextAcceptor;
        }

        void UnSetAcceptors()
        {
            fastTextBoxFind.TextAcceptor = null;
            fastTextBoxReplace.TextAcceptor = null;
        }

        private void ReplaceBox_Load(object sender, EventArgs e)
        {
            fastTextBoxFind.Text = searchParams.SearchString;
            fastTextBoxReplace.Text = searchParams.ReplaceString;

            LoadCheckboxes();

            // start pos at the corner of the parent window
            Location = new Point(Owner.Location.X + 40, Owner.Location.Y + 40);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveCheckboxes();
            SetSearchContext();

            DialogResult = DialogResult.Cancel;
            Close();
        }

        void CheckFindString()
        {
            string str;

            if (bInComboBoxMode)
                str = comboBoxFind.Text;
            else
                str = fastTextBoxFind.Text;

            if ((radioButtonName.Checked || radioButtonDescription.Checked) && bSetNumericAcceptors)
            {
                UnSetAcceptors();
                bSetNumericAcceptors = false;
            }

            if (IsANumericBoxTicked() && !bSetNumericAcceptors)
            {
                SetAcceptors();
                if (!string.IsNullOrEmpty(fastTextBoxFind.Text))
                {
                    if (!Int32TextAcceptor(null, fastTextBoxFind.Text, null, 0, 0))
                        fastTextBoxFind.Text = "";
                }
                bSetNumericAcceptors = true;
            }

            if (string.IsNullOrEmpty(str))
            {
                button1.Enabled = false;
                buttonReplace.Enabled = false;
                buttonReplaceAll.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                buttonReplace.Enabled = true;
                buttonReplaceAll.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckFindString();
           // CheckReplaceString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveCheckboxes();
            SetSearchContext();

            DialogResult = DialogResult.OK;
            form1.InitiateCardSearch(searchParams);
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            SaveCheckboxes();
            SetSearchContext();

            DialogResult = DialogResult.OK;
            form1.InitiateReplacing(searchParams);
        }

        private void buttonReplaceAll_Click(object sender, EventArgs e)
        {
            SaveCheckboxes();
            SetSearchContext();

            DialogResult = DialogResult.OK;
            form1.InitiateReplaceAll(searchParams);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchParams.SearchString = fastTextBoxFind.Text;
        }

        private void ReplaceBox_Activated(object sender, EventArgs e)
        {
            fastTextBoxFind.Focus();
        }

        private void fastTextBoxReplace_TextChanged(object sender, EventArgs e)
        {
            searchParams.ReplaceString = fastTextBoxReplace.Text;
        }

        private void SwitchToTextBox(object sender, EventArgs e) // defined in events for text inputs...
        {
            if ((radioButtonDescription.Checked || radioButtonName.Checked || IsANumericBoxTicked()) && bInComboBoxMode)
            {
                comboBoxFind.Visible = false;
                comboBoxReplace.Visible = false;
                fastTextBoxFind.Visible = true;
                fastTextBoxReplace.Visible = true;
                checkBoxMatch.Checked = bStringMatchWholeLastState;
                bInComboBoxMode = false;
                fastTextBoxFind.Text = "";
                fastTextBoxReplace.Text = "";
                searchParams.SearchString = "";
                searchParams.ReplaceString = "";
            }

            if (IsANumericBoxTicked())
            {
                checkBoxCase.Enabled = false;
                fastTextBoxFind.Text = "";
                fastTextBoxReplace.Text = "";
                searchParams.SearchString = "";
                searchParams.ReplaceString = "";
            }
            else
            {
                checkBoxCase.Enabled = true;
                checkBoxMatch.Enabled = true;
            }
        }

        private void SwitchToComboBox()
        {
            fastTextBoxFind.Visible = false;
            fastTextBoxReplace.Visible = false;
            checkBoxCase.Enabled = false;
            checkBoxMatch.Enabled = false;
            bStringMatchWholeLastState = checkBoxMatch.Checked;
            checkBoxMatch.Checked = true;
            comboBoxFind.Visible = true;
            comboBoxReplace.Visible = true;
            bInComboBoxMode = true;
            comboBoxFind.Text = "";
            comboBoxReplace.Text = "";
            searchParams.SearchString = "";
            searchParams.ReplaceString = "";
        }

        private void GenerateComboBox(Type EnumType)
        {
            var enumcount = Enum.GetNames(EnumType).Length;
            comboBoxFind.Items.Clear();
            comboBoxReplace.Items.Clear();

            for (int i = 0; i < enumcount; i++)
            {
                comboBoxFind.Items.Add(TypeDescriptor.GetConverter(EnumType).ConvertToString(i));
                comboBoxReplace.Items.Add(TypeDescriptor.GetConverter(EnumType).ConvertToString(i));
            }
            comboBoxFind.SelectedIndex = 0;
            comboBoxReplace.SelectedIndex = 0;
            searchParams.SearchComboBoxIndex = 0;
            searchParams.ReplaceComboBoxIndex = 0;
        }

        private void radioButtonKind_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKind.Checked)
            {
                SwitchToComboBox();
                GenerateComboBox(typeof(CardKinds));
            }
        }

        private void radioButtonType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonType.Checked)
            {
                SwitchToComboBox();
                GenerateComboBox(typeof(CardTypes));
            }
        }

        private void radioButtonAttr_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAttr.Checked)
            {
                SwitchToComboBox();
                GenerateComboBox(typeof(CardAttributes));
            }
        }

        private void radioButtonIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIcon.Checked)
            {
                SwitchToComboBox();
                GenerateComboBox(typeof(CardIcons));
            }
        }

        private void radioButtonRarity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRarity.Checked)
            {
                SwitchToComboBox();
                GenerateComboBox(typeof(CardRarity));
            }
        }

        private void radioButtonCardExists_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCardExists.Checked)
            {
                SwitchToComboBox();
                comboBoxFind.Items.Clear();
                comboBoxReplace.Items.Clear();

                comboBoxFind.Items.Add("False");
                comboBoxFind.Items.Add("True");
                comboBoxReplace.Items.Add("False");
                comboBoxReplace.Items.Add("True");

                comboBoxFind.SelectedIndex = 0;
                comboBoxReplace.SelectedIndex = 0;
                searchParams.SearchComboBoxIndex = 0;
                searchParams.ReplaceComboBoxIndex = 0;
            }
        }

        private void comboBoxFind_TextChanged(object sender, EventArgs e)
        {
            searchParams.SearchString = comboBoxFind.Text;
        }

        private void comboBoxReplace_TextChanged(object sender, EventArgs e)
        {
            searchParams.ReplaceString = comboBoxReplace.Text;
        }

        private void comboBoxFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchParams.SearchComboBoxIndex = comboBoxFind.SelectedIndex;
        }

        private void comboBoxReplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchParams.ReplaceComboBoxIndex = comboBoxReplace.SelectedIndex;
        }
    }
}
