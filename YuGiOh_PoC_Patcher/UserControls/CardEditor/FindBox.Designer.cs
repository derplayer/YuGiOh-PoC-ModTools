
namespace YuGiOh_PoC_Patcher.UserControls
{
    partial class FindBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindBox));
            this.findLabel = new System.Windows.Forms.Label();
            this.lookatBox = new System.Windows.Forms.GroupBox();
            this.checkBoxExists = new System.Windows.Forms.CheckBox();
            this.checkBoxPass = new System.Windows.Forms.CheckBox();
            this.checkBoxRarity = new System.Windows.Forms.CheckBox();
            this.checkBoxIcon = new System.Windows.Forms.CheckBox();
            this.checkBoxAttr = new System.Windows.Forms.CheckBox();
            this.checkBoxType = new System.Windows.Forms.CheckBox();
            this.checkBoxDEF = new System.Windows.Forms.CheckBox();
            this.checkBoxATK = new System.Windows.Forms.CheckBox();
            this.checkBoxLevel = new System.Windows.Forms.CheckBox();
            this.checkBoxKind = new System.Windows.Forms.CheckBox();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.checkBoxCardID = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBoxMatch = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxCase = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxDescription = new System.Windows.Forms.CheckBox();
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
            this.lookatBox.Controls.Add(this.checkBoxDescription);
            this.lookatBox.Controls.Add(this.checkBoxExists);
            this.lookatBox.Controls.Add(this.checkBoxPass);
            this.lookatBox.Controls.Add(this.checkBoxRarity);
            this.lookatBox.Controls.Add(this.checkBoxIcon);
            this.lookatBox.Controls.Add(this.checkBoxAttr);
            this.lookatBox.Controls.Add(this.checkBoxType);
            this.lookatBox.Controls.Add(this.checkBoxCardID);
            this.lookatBox.Controls.Add(this.checkBoxDEF);
            this.lookatBox.Controls.Add(this.checkBoxATK);
            this.lookatBox.Controls.Add(this.checkBoxLevel);
            this.lookatBox.Controls.Add(this.checkBoxKind);
            this.lookatBox.Controls.Add(this.checkBoxName);
            this.lookatBox.Location = new System.Drawing.Point(9, 45);
            this.lookatBox.Name = "lookatBox";
            this.lookatBox.Size = new System.Drawing.Size(336, 81);
            this.lookatBox.TabIndex = 2;
            this.lookatBox.TabStop = false;
            this.lookatBox.Text = "Look at";
            // 
            // checkBoxExists
            // 
            this.checkBoxExists.AutoSize = true;
            this.checkBoxExists.Location = new System.Drawing.Point(203, 57);
            this.checkBoxExists.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxExists.Name = "checkBoxExists";
            this.checkBoxExists.Size = new System.Drawing.Size(75, 17);
            this.checkBoxExists.TabIndex = 13;
            this.checkBoxExists.Text = "Card&Exists";
            this.checkBoxExists.UseVisualStyleBackColor = true;
            // 
            // checkBoxPass
            // 
            this.checkBoxPass.AutoSize = true;
            this.checkBoxPass.Location = new System.Drawing.Point(203, 38);
            this.checkBoxPass.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxPass.Name = "checkBoxPass";
            this.checkBoxPass.Size = new System.Drawing.Size(72, 17);
            this.checkBoxPass.TabIndex = 12;
            this.checkBoxPass.Text = "&Password";
            this.checkBoxPass.UseVisualStyleBackColor = true;
            // 
            // checkBoxRarity
            // 
            this.checkBoxRarity.AutoSize = true;
            this.checkBoxRarity.Location = new System.Drawing.Point(203, 19);
            this.checkBoxRarity.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxRarity.Name = "checkBoxRarity";
            this.checkBoxRarity.Size = new System.Drawing.Size(53, 17);
            this.checkBoxRarity.TabIndex = 12;
            this.checkBoxRarity.Text = "&Rarity";
            this.checkBoxRarity.UseVisualStyleBackColor = true;
            // 
            // checkBoxIcon
            // 
            this.checkBoxIcon.AutoSize = true;
            this.checkBoxIcon.Location = new System.Drawing.Point(138, 57);
            this.checkBoxIcon.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxIcon.Name = "checkBoxIcon";
            this.checkBoxIcon.Size = new System.Drawing.Size(47, 17);
            this.checkBoxIcon.TabIndex = 11;
            this.checkBoxIcon.Text = "I&con";
            this.checkBoxIcon.UseVisualStyleBackColor = true;
            // 
            // checkBoxAttr
            // 
            this.checkBoxAttr.AutoSize = true;
            this.checkBoxAttr.Location = new System.Drawing.Point(138, 38);
            this.checkBoxAttr.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAttr.Name = "checkBoxAttr";
            this.checkBoxAttr.Size = new System.Drawing.Size(65, 17);
            this.checkBoxAttr.TabIndex = 10;
            this.checkBoxAttr.Text = "Attri&bute";
            this.checkBoxAttr.UseVisualStyleBackColor = true;
            // 
            // checkBoxType
            // 
            this.checkBoxType.AutoSize = true;
            this.checkBoxType.Location = new System.Drawing.Point(138, 19);
            this.checkBoxType.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxType.Name = "checkBoxType";
            this.checkBoxType.Size = new System.Drawing.Size(50, 17);
            this.checkBoxType.TabIndex = 9;
            this.checkBoxType.Text = "&Type";
            this.checkBoxType.UseVisualStyleBackColor = true;
            // 
            // checkBoxDEF
            // 
            this.checkBoxDEF.AutoSize = true;
            this.checkBoxDEF.Location = new System.Drawing.Point(86, 57);
            this.checkBoxDEF.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDEF.Name = "checkBoxDEF";
            this.checkBoxDEF.Size = new System.Drawing.Size(47, 17);
            this.checkBoxDEF.TabIndex = 8;
            this.checkBoxDEF.Text = "&DEF";
            this.checkBoxDEF.UseVisualStyleBackColor = true;
            // 
            // checkBoxATK
            // 
            this.checkBoxATK.AutoSize = true;
            this.checkBoxATK.Location = new System.Drawing.Point(86, 38);
            this.checkBoxATK.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxATK.Name = "checkBoxATK";
            this.checkBoxATK.Size = new System.Drawing.Size(47, 17);
            this.checkBoxATK.TabIndex = 7;
            this.checkBoxATK.Text = "&ATK";
            this.checkBoxATK.UseVisualStyleBackColor = true;
            // 
            // checkBoxLevel
            // 
            this.checkBoxLevel.AutoSize = true;
            this.checkBoxLevel.Location = new System.Drawing.Point(86, 19);
            this.checkBoxLevel.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxLevel.Name = "checkBoxLevel";
            this.checkBoxLevel.Size = new System.Drawing.Size(52, 17);
            this.checkBoxLevel.TabIndex = 6;
            this.checkBoxLevel.Text = "&Level";
            this.checkBoxLevel.UseVisualStyleBackColor = true;
            // 
            // checkBoxKind
            // 
            this.checkBoxKind.AutoSize = true;
            this.checkBoxKind.Location = new System.Drawing.Point(7, 57);
            this.checkBoxKind.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxKind.Name = "checkBoxKind";
            this.checkBoxKind.Size = new System.Drawing.Size(47, 17);
            this.checkBoxKind.TabIndex = 5;
            this.checkBoxKind.Text = "&Kind";
            this.checkBoxKind.UseVisualStyleBackColor = true;
            // 
            // checkBoxName
            // 
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Location = new System.Drawing.Point(7, 19);
            this.checkBoxName.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(54, 17);
            this.checkBoxName.TabIndex = 4;
            this.checkBoxName.Text = "&Name";
            this.checkBoxName.UseVisualStyleBackColor = true;
            // 
            // checkBoxCardID
            // 
            this.checkBoxCardID.AutoSize = true;
            this.checkBoxCardID.Location = new System.Drawing.Point(275, 19);
            this.checkBoxCardID.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxCardID.Name = "checkBoxCardID";
            this.checkBoxCardID.Size = new System.Drawing.Size(59, 17);
            this.checkBoxCardID.TabIndex = 3;
            this.checkBoxCardID.Text = "Card&ID";
            this.checkBoxCardID.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(353, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "&Find Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(353, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBoxMatch
            // 
            this.checkBoxMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxMatch.AutoSize = true;
            this.checkBoxMatch.Location = new System.Drawing.Point(9, 129);
            this.checkBoxMatch.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxMatch.Name = "checkBoxMatch";
            this.checkBoxMatch.Size = new System.Drawing.Size(137, 17);
            this.checkBoxMatch.TabIndex = 14;
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
            this.checkBoxCase.Location = new System.Drawing.Point(146, 129);
            this.checkBoxCase.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(82, 17);
            this.checkBoxCase.TabIndex = 15;
            this.checkBoxCase.Text = "Matc&h case";
            this.checkBoxCase.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkBoxDescription
            // 
            this.checkBoxDescription.AutoSize = true;
            this.checkBoxDescription.Location = new System.Drawing.Point(7, 38);
            this.checkBoxDescription.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxDescription.Name = "checkBoxDescription";
            this.checkBoxDescription.Size = new System.Drawing.Size(79, 17);
            this.checkBoxDescription.TabIndex = 14;
            this.checkBoxDescription.Text = "De&scription";
            this.checkBoxDescription.UseVisualStyleBackColor = true;
            // 
            // FindBox
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(438, 151);
            this.Controls.Add(this.textBox1);
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
            this.Name = "FindBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Find";
            this.Activated += new System.EventHandler(this.FindBox_Activated);
            this.Load += new System.EventHandler(this.FindBox_Load);
            this.lookatBox.ResumeLayout(false);
            this.lookatBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label findLabel;
        private System.Windows.Forms.GroupBox lookatBox;
        private System.Windows.Forms.CheckBox checkBoxKind;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.CheckBox checkBoxCardID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBoxLevel;
        private System.Windows.Forms.CheckBox checkBoxDEF;
        private System.Windows.Forms.CheckBox checkBoxATK;
        private System.Windows.Forms.CheckBox checkBoxIcon;
        private System.Windows.Forms.CheckBox checkBoxAttr;
        private System.Windows.Forms.CheckBox checkBoxType;
        private System.Windows.Forms.CheckBox checkBoxExists;
        private System.Windows.Forms.CheckBox checkBoxPass;
        private System.Windows.Forms.CheckBox checkBoxRarity;
        private System.Windows.Forms.CheckBox checkBoxMatch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxCase;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxDescription;
    }
}