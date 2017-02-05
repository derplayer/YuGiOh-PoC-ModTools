namespace YuGiOh_PoC_Patcher.UserControls
{
    partial class PointBundleUserControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_X = new System.Windows.Forms.Panel();
            this.label_X = new System.Windows.Forms.Label();
            this.numericUpDown_X = new System.Windows.Forms.NumericUpDown();
            this.panel_Y = new System.Windows.Forms.Panel();
            this.label_Y = new System.Windows.Forms.Label();
            this.numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
            this.panel_Gap = new System.Windows.Forms.Panel();
            this.label_Gap = new System.Windows.Forms.Label();
            this.numericUpDown_Gap = new System.Windows.Forms.NumericUpDown();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_X.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).BeginInit();
            this.panel_Y.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).BeginInit();
            this.panel_Gap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Gap)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.tableLayoutPanel1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(150, 168);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "NaN";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel_X, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_Y, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_Gap, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(144, 149);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel_X
            // 
            this.panel_X.Controls.Add(this.label_X);
            this.panel_X.Controls.Add(this.numericUpDown_X);
            this.panel_X.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_X.Location = new System.Drawing.Point(3, 3);
            this.panel_X.Name = "panel_X";
            this.panel_X.Size = new System.Drawing.Size(138, 43);
            this.panel_X.TabIndex = 0;
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(3, 5);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(48, 13);
            this.label_X.TabIndex = 0;
            this.label_X.Text = "Offset X:";
            // 
            // numericUpDown_X
            // 
            this.numericUpDown_X.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_X.Location = new System.Drawing.Point(55, 3);
            this.numericUpDown_X.Name = "numericUpDown_X";
            this.numericUpDown_X.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown_X.TabIndex = 3;
            // 
            // panel_Y
            // 
            this.panel_Y.Controls.Add(this.label_Y);
            this.panel_Y.Controls.Add(this.numericUpDown_Y);
            this.panel_Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Y.Location = new System.Drawing.Point(3, 52);
            this.panel_Y.Name = "panel_Y";
            this.panel_Y.Size = new System.Drawing.Size(138, 43);
            this.panel_Y.TabIndex = 1;
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(3, 5);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(48, 13);
            this.label_Y.TabIndex = 1;
            this.label_Y.Text = "Offset Y:";
            // 
            // numericUpDown_Y
            // 
            this.numericUpDown_Y.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Y.Location = new System.Drawing.Point(55, 3);
            this.numericUpDown_Y.Name = "numericUpDown_Y";
            this.numericUpDown_Y.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown_Y.TabIndex = 2;
            // 
            // panel_Gap
            // 
            this.panel_Gap.Controls.Add(this.label_Gap);
            this.panel_Gap.Controls.Add(this.numericUpDown_Gap);
            this.panel_Gap.Location = new System.Drawing.Point(3, 101);
            this.panel_Gap.Name = "panel_Gap";
            this.panel_Gap.Size = new System.Drawing.Size(138, 45);
            this.panel_Gap.TabIndex = 2;
            // 
            // label_Gap
            // 
            this.label_Gap.AutoSize = true;
            this.label_Gap.Location = new System.Drawing.Point(19, 5);
            this.label_Gap.Name = "label_Gap";
            this.label_Gap.Size = new System.Drawing.Size(30, 13);
            this.label_Gap.TabIndex = 3;
            this.label_Gap.Text = "Gap:";
            // 
            // numericUpDown_Gap
            // 
            this.numericUpDown_Gap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Gap.Location = new System.Drawing.Point(55, 3);
            this.numericUpDown_Gap.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Gap.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Gap.Name = "numericUpDown_Gap";
            this.numericUpDown_Gap.Size = new System.Drawing.Size(80, 20);
            this.numericUpDown_Gap.TabIndex = 4;
            // 
            // PointBundleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "PointBundleUserControl";
            this.Size = new System.Drawing.Size(150, 168);
            this.groupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_X.ResumeLayout(false);
            this.panel_X.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_X)).EndInit();
            this.panel_Y.ResumeLayout(false);
            this.panel_Y.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Y)).EndInit();
            this.panel_Gap.ResumeLayout(false);
            this.panel_Gap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Gap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_X;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.NumericUpDown numericUpDown_X;
        private System.Windows.Forms.Panel panel_Y;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.NumericUpDown numericUpDown_Y;
        private System.Windows.Forms.Panel panel_Gap;
        private System.Windows.Forms.Label label_Gap;
        private System.Windows.Forms.NumericUpDown numericUpDown_Gap;
    }
}
