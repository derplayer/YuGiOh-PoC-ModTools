namespace YuGiOh_PoC_Patcher
{
    partial class PointUserControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.valueUserControl_X = new YuGiOh_PoC_Patcher.ValueUserControl();
            this.valueUserControl_Y = new YuGiOh_PoC_Patcher.ValueUserControl();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.tableLayoutPanel);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(150, 150);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "NaN";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.valueUserControl_X, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.valueUserControl_Y, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(144, 131);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // valueUserControl_X
            // 
            this.valueUserControl_X.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueUserControl_X.Location = new System.Drawing.Point(0, 0);
            this.valueUserControl_X.Margin = new System.Windows.Forms.Padding(0);
            this.valueUserControl_X.Name = "valueUserControl_X";
            this.valueUserControl_X.Size = new System.Drawing.Size(144, 28);
            this.valueUserControl_X.TabIndex = 0;
            this.valueUserControl_X.Value = null;
            this.valueUserControl_X.ValueText = "Offset X:";
            // 
            // valueUserControl_Y
            // 
            this.valueUserControl_Y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueUserControl_Y.Location = new System.Drawing.Point(0, 28);
            this.valueUserControl_Y.Margin = new System.Windows.Forms.Padding(0);
            this.valueUserControl_Y.Name = "valueUserControl_Y";
            this.valueUserControl_Y.Size = new System.Drawing.Size(144, 28);
            this.valueUserControl_Y.TabIndex = 1;
            this.valueUserControl_Y.Value = null;
            this.valueUserControl_Y.ValueText = "Offset Y:";
            // 
            // PointUserControl
            // 
            this.Controls.Add(this.groupBox);
            this.Name = "PointUserControl";
            this.groupBox.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ValueUserControl valueUserControl_X;
        private ValueUserControl valueUserControl_Y;
    }
}
