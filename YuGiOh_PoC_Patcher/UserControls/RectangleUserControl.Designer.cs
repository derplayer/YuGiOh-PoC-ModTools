namespace YuGiOh_PoC_Patcher.UserControls
{
    partial class RectangleUserControl
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
            this.valueUserControl_Left = new YuGiOh_PoC_Patcher.ValueUserControl();
            this.valueUserControl_Top = new YuGiOh_PoC_Patcher.ValueUserControl();
            this.valueUserControl_Right = new YuGiOh_PoC_Patcher.ValueUserControl();
            this.valueUserControl_Bottom = new YuGiOh_PoC_Patcher.ValueUserControl();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.valueUserControl_Bottom, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.valueUserControl_Right, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.valueUserControl_Top, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.valueUserControl_Left, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(144, 131);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // valueUserControl_Left
            // 
            this.valueUserControl_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueUserControl_Left.Location = new System.Drawing.Point(0, 0);
            this.valueUserControl_Left.Margin = new System.Windows.Forms.Padding(0);
            this.valueUserControl_Left.Name = "valueUserControl_Left";
            this.valueUserControl_Left.Size = new System.Drawing.Size(144, 28);
            this.valueUserControl_Left.TabIndex = 0;
            this.valueUserControl_Left.Value = null;
            this.valueUserControl_Left.ValueText = "Left:";
            // 
            // valueUserControl_Top
            // 
            this.valueUserControl_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueUserControl_Top.Location = new System.Drawing.Point(0, 28);
            this.valueUserControl_Top.Margin = new System.Windows.Forms.Padding(0);
            this.valueUserControl_Top.Name = "valueUserControl_Top";
            this.valueUserControl_Top.Size = new System.Drawing.Size(144, 28);
            this.valueUserControl_Top.TabIndex = 1;
            this.valueUserControl_Top.Value = null;
            this.valueUserControl_Top.ValueText = "Top:";
            // 
            // valueUserControl_Right
            // 
            this.valueUserControl_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueUserControl_Right.Location = new System.Drawing.Point(0, 56);
            this.valueUserControl_Right.Margin = new System.Windows.Forms.Padding(0);
            this.valueUserControl_Right.Name = "valueUserControl_Right";
            this.valueUserControl_Right.Size = new System.Drawing.Size(144, 28);
            this.valueUserControl_Right.TabIndex = 2;
            this.valueUserControl_Right.Value = null;
            this.valueUserControl_Right.ValueText = "Right:";
            // 
            // valueUserControl_Bottom
            // 
            this.valueUserControl_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueUserControl_Bottom.Location = new System.Drawing.Point(0, 84);
            this.valueUserControl_Bottom.Margin = new System.Windows.Forms.Padding(0);
            this.valueUserControl_Bottom.Name = "valueUserControl_Bottom";
            this.valueUserControl_Bottom.Size = new System.Drawing.Size(144, 28);
            this.valueUserControl_Bottom.TabIndex = 3;
            this.valueUserControl_Bottom.Value = null;
            this.valueUserControl_Bottom.ValueText = "Bottom:";
            // 
            // RectangleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Name = "RectangleUserControl";
            this.groupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ValueUserControl valueUserControl_Left;
        private ValueUserControl valueUserControl_Bottom;
        private ValueUserControl valueUserControl_Right;
        private ValueUserControl valueUserControl_Top;
    }
}
