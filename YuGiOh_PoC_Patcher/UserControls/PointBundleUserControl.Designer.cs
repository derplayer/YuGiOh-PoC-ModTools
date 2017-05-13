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
            this.panel_Gap = new System.Windows.Forms.Panel();
            this.numericUpDown_Gap = new System.Windows.Forms.NumericUpDown();
            this.label_Gap = new System.Windows.Forms.Label();
            this.valueUserControl_Y = new YuGiOh_PoC_Patcher.ValueUserControl();
            this.valueUserControl_X = new YuGiOh_PoC_Patcher.ValueUserControl();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.groupBox.Size = new System.Drawing.Size(150, 150);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "NaN";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.valueUserControl_Y, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_Gap, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.valueUserControl_X, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(144, 131);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel_Gap
            // 
            this.panel_Gap.Controls.Add(this.label_Gap);
            this.panel_Gap.Controls.Add(this.numericUpDown_Gap);
            this.panel_Gap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Gap.Location = new System.Drawing.Point(0, 56);
            this.panel_Gap.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Gap.Name = "panel_Gap";
            this.panel_Gap.Size = new System.Drawing.Size(144, 28);
            this.panel_Gap.TabIndex = 2;
            // 
            // numericUpDown_Gap
            // 
            this.numericUpDown_Gap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Gap.Location = new System.Drawing.Point(61, 3);
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
            this.numericUpDown_Gap.ValueChanged += new System.EventHandler(this.numericUpDown_Gap_ValueChanged);
            // 
            // label_Gap
            // 
            this.label_Gap.AutoSize = true;
            this.label_Gap.Location = new System.Drawing.Point(30, 6);
            this.label_Gap.Name = "label_Gap";
            this.label_Gap.Size = new System.Drawing.Size(30, 13);
            this.label_Gap.TabIndex = 3;
            this.label_Gap.Text = "Gap:";
            // 
            // valueUserControl_Y
            // 
            this.valueUserControl_Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueUserControl_Y.Location = new System.Drawing.Point(0, 28);
            this.valueUserControl_Y.Margin = new System.Windows.Forms.Padding(0);
            this.valueUserControl_Y.Name = "valueUserControl_Y";
            this.valueUserControl_Y.Size = new System.Drawing.Size(144, 28);
            this.valueUserControl_Y.TabIndex = 4;
            this.valueUserControl_Y.Value = null;
            this.valueUserControl_Y.ValueText = "Offset Y:";
            // 
            // valueUserControl_X
            // 
            this.valueUserControl_X.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueUserControl_X.Location = new System.Drawing.Point(0, 0);
            this.valueUserControl_X.Margin = new System.Windows.Forms.Padding(0);
            this.valueUserControl_X.Name = "valueUserControl_X";
            this.valueUserControl_X.Size = new System.Drawing.Size(144, 28);
            this.valueUserControl_X.TabIndex = 3;
            this.valueUserControl_X.Value = null;
            this.valueUserControl_X.ValueText = "Offset X:";
            // 
            // PointBundleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "PointBundleUserControl";
            this.groupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_Gap.ResumeLayout(false);
            this.panel_Gap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Gap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_Gap;
        private System.Windows.Forms.NumericUpDown numericUpDown_Gap;
        private ValueUserControl valueUserControl_Y;
        private System.Windows.Forms.Label label_Gap;
        private ValueUserControl valueUserControl_X;
    }
}
