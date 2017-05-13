namespace YuGiOh_PoC_Patcher.UserControls
{
    partial class ValueListUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label_ValueText = new System.Windows.Forms.Label();
            this.numericUpDown_Value = new System.Windows.Forms.NumericUpDown();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label_ValueText);
            this.groupBox.Controls.Add(this.numericUpDown_Value);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(150, 150);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "NaN";
            // 
            // label_ValueText
            // 
            this.label_ValueText.Location = new System.Drawing.Point(3, 16);
            this.label_ValueText.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label_ValueText.Name = "label_ValueText";
            this.label_ValueText.Size = new System.Drawing.Size(60, 24);
            this.label_ValueText.TabIndex = 6;
            this.label_ValueText.Text = "Value:";
            this.label_ValueText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Value
            // 
            this.numericUpDown_Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Value.Location = new System.Drawing.Point(64, 19);
            this.numericUpDown_Value.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Value.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Value.Name = "numericUpDown_Value";
            this.numericUpDown_Value.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown_Value.TabIndex = 7;
            // 
            // ValueListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "ValueListUserControl";
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label_ValueText;
        private System.Windows.Forms.NumericUpDown numericUpDown_Value;
    }
}
