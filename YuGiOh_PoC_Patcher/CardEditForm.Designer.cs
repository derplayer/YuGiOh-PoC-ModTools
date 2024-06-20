namespace YuGiOh_PoC_Patcher
{
    partial class CardEditForm
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
            this.formCardEdit1 = new YuGiOh_PoC_Patcher.UserControls.FormCardEdit();
            this.SuspendLayout();
            // 
            // formCardEdit1
            // 
            this.formCardEdit1.AllowDrop = true;
            this.formCardEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formCardEdit1.Location = new System.Drawing.Point(0, 0);
            this.formCardEdit1.MinimumSize = new System.Drawing.Size(693, 448);
            this.formCardEdit1.Name = "formCardEdit1";
            this.formCardEdit1.Size = new System.Drawing.Size(1194, 557);
            this.formCardEdit1.TabIndex = 0;
            // 
            // CardEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 557);
            this.Controls.Add(this.formCardEdit1);
            this.Name = "CardEditForm";
            this.Text = "Card editor";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.FormCardEdit formCardEdit1;
    }
}