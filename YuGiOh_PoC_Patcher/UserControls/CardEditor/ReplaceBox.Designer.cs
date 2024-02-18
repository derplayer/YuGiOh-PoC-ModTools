
namespace YuGiOh_PoC_Patcher.UserControls
{
    partial class ReplaceBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaceBox));
            this.findLabel = new System.Windows.Forms.Label();
            this.lookatBox = new System.Windows.Forms.GroupBox();
            this.radioButtonCardExists = new System.Windows.Forms.RadioButton();
            this.radioButtonRarity = new System.Windows.Forms.RadioButton();
            this.radioButtonPassword = new System.Windows.Forms.RadioButton();
            this.radioButtonIcon = new System.Windows.Forms.RadioButton();
            this.radioButtonAttr = new System.Windows.Forms.RadioButton();
            this.radioButtonType = new System.Windows.Forms.RadioButton();
            this.radioButtonDEF = new System.Windows.Forms.RadioButton();
            this.radioButtonATK = new System.Windows.Forms.RadioButton();
            this.radioButtonLevel = new System.Windows.Forms.RadioButton();
            this.radioButtonKind = new System.Windows.Forms.RadioButton();
            this.radioButtonName = new System.Windows.Forms.RadioButton();
            this.radioButtonDescription = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBoxMatch = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxCase = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.buttonReplaceAll = new System.Windows.Forms.Button();
            this.comboBoxFind = new System.Windows.Forms.ComboBox();
            this.comboBoxReplace = new System.Windows.Forms.ComboBox();
            this.fastTextBoxFind = new FastTextBox();
            this.fastTextBoxReplace = new FastTextBox();
            this.lookatBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // findLabel
            // 
            this.findLabel.AutoSize = true;
            this.findLabel.Location = new System.Drawing.Point(6, 13);
            this.findLabel.Name = "findLabel";
            this.findLabel.Size = new System.Drawing.Size(56, 13);
            this.findLabel.TabIndex = 0;
            this.findLabel.Text = "Fi&nd what:";
            // 
            // lookatBox
            // 
            this.lookatBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lookatBox.Controls.Add(this.radioButtonCardExists);
            this.lookatBox.Controls.Add(this.radioButtonRarity);
            this.lookatBox.Controls.Add(this.radioButtonPassword);
            this.lookatBox.Controls.Add(this.radioButtonIcon);
            this.lookatBox.Controls.Add(this.radioButtonAttr);
            this.lookatBox.Controls.Add(this.radioButtonType);
            this.lookatBox.Controls.Add(this.radioButtonDEF);
            this.lookatBox.Controls.Add(this.radioButtonATK);
            this.lookatBox.Controls.Add(this.radioButtonLevel);
            this.lookatBox.Controls.Add(this.radioButtonKind);
            this.lookatBox.Controls.Add(this.radioButtonName);
            this.lookatBox.Controls.Add(this.radioButtonDescription);
            this.lookatBox.Location = new System.Drawing.Point(9, 69);
            this.lookatBox.Name = "lookatBox";
            this.lookatBox.Size = new System.Drawing.Size(281, 81);
            this.lookatBox.TabIndex = 7;
            this.lookatBox.TabStop = false;
            this.lookatBox.Text = "Look at";
            // 
            // radioButtonCardExists
            // 
            this.radioButtonCardExists.AutoSize = true;
            this.radioButtonCardExists.Location = new System.Drawing.Point(196, 50);
            this.radioButtonCardExists.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonCardExists.Name = "radioButtonCardExists";
            this.radioButtonCardExists.Size = new System.Drawing.Size(74, 17);
            this.radioButtonCardExists.TabIndex = 19;
            this.radioButtonCardExists.Text = "CardExists";
            this.radioButtonCardExists.UseVisualStyleBackColor = true;
            this.radioButtonCardExists.CheckedChanged += new System.EventHandler(this.radioButtonCardExists_CheckedChanged);
            // 
            // radioButtonRarity
            // 
            this.radioButtonRarity.AutoSize = true;
            this.radioButtonRarity.Location = new System.Drawing.Point(196, 16);
            this.radioButtonRarity.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonRarity.Name = "radioButtonRarity";
            this.radioButtonRarity.Size = new System.Drawing.Size(52, 17);
            this.radioButtonRarity.TabIndex = 17;
            this.radioButtonRarity.Text = "Rarity";
            this.radioButtonRarity.UseVisualStyleBackColor = true;
            this.radioButtonRarity.CheckedChanged += new System.EventHandler(this.radioButtonRarity_CheckedChanged);
            // 
            // radioButtonPassword
            // 
            this.radioButtonPassword.AutoSize = true;
            this.radioButtonPassword.Location = new System.Drawing.Point(196, 33);
            this.radioButtonPassword.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonPassword.Name = "radioButtonPassword";
            this.radioButtonPassword.Size = new System.Drawing.Size(71, 17);
            this.radioButtonPassword.TabIndex = 18;
            this.radioButtonPassword.Text = "Password";
            this.radioButtonPassword.UseVisualStyleBackColor = true;
            this.radioButtonPassword.CheckedChanged += new System.EventHandler(this.SwitchToTextBox);
            // 
            // radioButtonIcon
            // 
            this.radioButtonIcon.AutoSize = true;
            this.radioButtonIcon.Location = new System.Drawing.Point(132, 50);
            this.radioButtonIcon.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonIcon.Name = "radioButtonIcon";
            this.radioButtonIcon.Size = new System.Drawing.Size(46, 17);
            this.radioButtonIcon.TabIndex = 16;
            this.radioButtonIcon.Text = "Icon";
            this.radioButtonIcon.UseVisualStyleBackColor = true;
            this.radioButtonIcon.CheckedChanged += new System.EventHandler(this.radioButtonIcon_CheckedChanged);
            // 
            // radioButtonAttr
            // 
            this.radioButtonAttr.AutoSize = true;
            this.radioButtonAttr.Location = new System.Drawing.Point(132, 33);
            this.radioButtonAttr.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonAttr.Name = "radioButtonAttr";
            this.radioButtonAttr.Size = new System.Drawing.Size(64, 17);
            this.radioButtonAttr.TabIndex = 15;
            this.radioButtonAttr.Text = "Attribute";
            this.radioButtonAttr.UseVisualStyleBackColor = true;
            this.radioButtonAttr.CheckedChanged += new System.EventHandler(this.radioButtonAttr_CheckedChanged);
            // 
            // radioButtonType
            // 
            this.radioButtonType.AutoSize = true;
            this.radioButtonType.Location = new System.Drawing.Point(132, 16);
            this.radioButtonType.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonType.Name = "radioButtonType";
            this.radioButtonType.Size = new System.Drawing.Size(49, 17);
            this.radioButtonType.TabIndex = 14;
            this.radioButtonType.Text = "Type";
            this.radioButtonType.UseVisualStyleBackColor = true;
            this.radioButtonType.CheckedChanged += new System.EventHandler(this.radioButtonType_CheckedChanged);
            // 
            // radioButtonDEF
            // 
            this.radioButtonDEF.AutoSize = true;
            this.radioButtonDEF.Location = new System.Drawing.Point(81, 50);
            this.radioButtonDEF.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonDEF.Name = "radioButtonDEF";
            this.radioButtonDEF.Size = new System.Drawing.Size(46, 17);
            this.radioButtonDEF.TabIndex = 13;
            this.radioButtonDEF.Text = "DEF";
            this.radioButtonDEF.UseVisualStyleBackColor = true;
            this.radioButtonDEF.CheckedChanged += new System.EventHandler(this.SwitchToTextBox);
            // 
            // radioButtonATK
            // 
            this.radioButtonATK.AutoSize = true;
            this.radioButtonATK.Location = new System.Drawing.Point(81, 33);
            this.radioButtonATK.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonATK.Name = "radioButtonATK";
            this.radioButtonATK.Size = new System.Drawing.Size(46, 17);
            this.radioButtonATK.TabIndex = 12;
            this.radioButtonATK.Text = "ATK";
            this.radioButtonATK.UseVisualStyleBackColor = true;
            this.radioButtonATK.CheckedChanged += new System.EventHandler(this.SwitchToTextBox);
            // 
            // radioButtonLevel
            // 
            this.radioButtonLevel.AutoSize = true;
            this.radioButtonLevel.Location = new System.Drawing.Point(81, 16);
            this.radioButtonLevel.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonLevel.Name = "radioButtonLevel";
            this.radioButtonLevel.Size = new System.Drawing.Size(51, 17);
            this.radioButtonLevel.TabIndex = 11;
            this.radioButtonLevel.Text = "Level";
            this.radioButtonLevel.UseVisualStyleBackColor = true;
            this.radioButtonLevel.CheckedChanged += new System.EventHandler(this.SwitchToTextBox);
            // 
            // radioButtonKind
            // 
            this.radioButtonKind.AutoSize = true;
            this.radioButtonKind.Location = new System.Drawing.Point(3, 50);
            this.radioButtonKind.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonKind.Name = "radioButtonKind";
            this.radioButtonKind.Size = new System.Drawing.Size(46, 17);
            this.radioButtonKind.TabIndex = 10;
            this.radioButtonKind.Text = "Kind";
            this.radioButtonKind.UseVisualStyleBackColor = true;
            this.radioButtonKind.CheckedChanged += new System.EventHandler(this.radioButtonKind_CheckedChanged);
            // 
            // radioButtonName
            // 
            this.radioButtonName.AutoSize = true;
            this.radioButtonName.Checked = true;
            this.radioButtonName.Location = new System.Drawing.Point(3, 16);
            this.radioButtonName.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonName.Name = "radioButtonName";
            this.radioButtonName.Size = new System.Drawing.Size(53, 17);
            this.radioButtonName.TabIndex = 8;
            this.radioButtonName.TabStop = true;
            this.radioButtonName.Text = "Name";
            this.radioButtonName.UseVisualStyleBackColor = true;
            this.radioButtonName.CheckedChanged += new System.EventHandler(this.SwitchToTextBox);
            // 
            // radioButtonDescription
            // 
            this.radioButtonDescription.AutoSize = true;
            this.radioButtonDescription.Location = new System.Drawing.Point(3, 33);
            this.radioButtonDescription.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonDescription.Name = "radioButtonDescription";
            this.radioButtonDescription.Size = new System.Drawing.Size(78, 17);
            this.radioButtonDescription.TabIndex = 9;
            this.radioButtonDescription.Text = "Description";
            this.radioButtonDescription.UseVisualStyleBackColor = true;
            this.radioButtonDescription.CheckedChanged += new System.EventHandler(this.SwitchToTextBox);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(316, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Find Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(316, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBoxMatch
            // 
            this.checkBoxMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxMatch.AutoSize = true;
            this.checkBoxMatch.Location = new System.Drawing.Point(9, 153);
            this.checkBoxMatch.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxMatch.Name = "checkBoxMatch";
            this.checkBoxMatch.Size = new System.Drawing.Size(137, 17);
            this.checkBoxMatch.TabIndex = 20;
            this.checkBoxMatch.Text = "Match &whole string only";
            this.checkBoxMatch.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxCase
            // 
            this.checkBoxCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCase.AutoSize = true;
            this.checkBoxCase.Location = new System.Drawing.Point(146, 153);
            this.checkBoxCase.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(82, 17);
            this.checkBoxCase.TabIndex = 21;
            this.checkBoxCase.Text = "Matc&h case";
            this.checkBoxCase.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Re&place with:";
            // 
            // buttonReplace
            // 
            this.buttonReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReplace.Location = new System.Drawing.Point(316, 37);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(75, 23);
            this.buttonReplace.TabIndex = 5;
            this.buttonReplace.Text = "&Replace";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // buttonReplaceAll
            // 
            this.buttonReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReplaceAll.Location = new System.Drawing.Point(316, 66);
            this.buttonReplaceAll.Name = "buttonReplaceAll";
            this.buttonReplaceAll.Size = new System.Drawing.Size(75, 23);
            this.buttonReplaceAll.TabIndex = 6;
            this.buttonReplaceAll.Text = "Replace &All";
            this.buttonReplaceAll.UseVisualStyleBackColor = true;
            this.buttonReplaceAll.Click += new System.EventHandler(this.buttonReplaceAll_Click);
            // 
            // comboBoxFind
            // 
            this.comboBoxFind.FormattingEnabled = true;
            this.comboBoxFind.Location = new System.Drawing.Point(84, 10);
            this.comboBoxFind.Name = "comboBoxFind";
            this.comboBoxFind.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFind.TabIndex = 1;
            this.comboBoxFind.Visible = false;
            this.comboBoxFind.SelectedIndexChanged += new System.EventHandler(this.comboBoxFind_SelectedIndexChanged);
            this.comboBoxFind.TextChanged += new System.EventHandler(this.comboBoxFind_TextChanged);
            // 
            // comboBoxReplace
            // 
            this.comboBoxReplace.FormattingEnabled = true;
            this.comboBoxReplace.Location = new System.Drawing.Point(84, 39);
            this.comboBoxReplace.Name = "comboBoxReplace";
            this.comboBoxReplace.Size = new System.Drawing.Size(121, 21);
            this.comboBoxReplace.TabIndex = 3;
            this.comboBoxReplace.Visible = false;
            this.comboBoxReplace.SelectedIndexChanged += new System.EventHandler(this.comboBoxReplace_SelectedIndexChanged);
            this.comboBoxReplace.TextChanged += new System.EventHandler(this.comboBoxReplace_TextChanged);
            // 
            // fastTextBoxFind
            // 
            this.fastTextBoxFind.Hint = "";
            this.fastTextBoxFind.Location = new System.Drawing.Point(84, 10);
            this.fastTextBoxFind.Name = "fastTextBoxFind";
            this.fastTextBoxFind.Size = new System.Drawing.Size(222, 20);
            this.fastTextBoxFind.TabIndex = 1;
            this.fastTextBoxFind.TextAcceptor = null;
            this.fastTextBoxFind.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // fastTextBoxReplace
            // 
            this.fastTextBoxReplace.Hint = "";
            this.fastTextBoxReplace.Location = new System.Drawing.Point(84, 39);
            this.fastTextBoxReplace.Name = "fastTextBoxReplace";
            this.fastTextBoxReplace.Size = new System.Drawing.Size(222, 20);
            this.fastTextBoxReplace.TabIndex = 3;
            this.fastTextBoxReplace.TextAcceptor = null;
            this.fastTextBoxReplace.TextChanged += new System.EventHandler(this.fastTextBoxReplace_TextChanged);
            // 
            // ReplaceBox
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(401, 175);
            this.Controls.Add(this.comboBoxReplace);
            this.Controls.Add(this.comboBoxFind);
            this.Controls.Add(this.buttonReplaceAll);
            this.Controls.Add(this.buttonReplace);
            this.Controls.Add(this.fastTextBoxFind);
            this.Controls.Add(this.fastTextBoxReplace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxCase);
            this.Controls.Add(this.checkBoxMatch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lookatBox);
            this.Controls.Add(this.findLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Replace";
            this.Activated += new System.EventHandler(this.ReplaceBox_Activated);
            this.Load += new System.EventHandler(this.ReplaceBox_Load);
            this.lookatBox.ResumeLayout(false);
            this.lookatBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label findLabel;
        private System.Windows.Forms.GroupBox lookatBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBoxMatch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxCase;
        private System.Windows.Forms.Label label1;
        private FastTextBox fastTextBoxReplace;
        private FastTextBox fastTextBoxFind;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Button buttonReplaceAll;
        private System.Windows.Forms.RadioButton radioButtonName;
        private System.Windows.Forms.RadioButton radioButtonDescription;
        private System.Windows.Forms.RadioButton radioButtonCardExists;
        private System.Windows.Forms.RadioButton radioButtonRarity;
        private System.Windows.Forms.RadioButton radioButtonPassword;
        private System.Windows.Forms.RadioButton radioButtonIcon;
        private System.Windows.Forms.RadioButton radioButtonAttr;
        private System.Windows.Forms.RadioButton radioButtonType;
        private System.Windows.Forms.RadioButton radioButtonDEF;
        private System.Windows.Forms.RadioButton radioButtonATK;
        private System.Windows.Forms.RadioButton radioButtonLevel;
        private System.Windows.Forms.RadioButton radioButtonKind;
        private System.Windows.Forms.ComboBox comboBoxFind;
        private System.Windows.Forms.ComboBox comboBoxReplace;
    }
}