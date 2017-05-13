namespace YuGiOh_PoC_Patcher
{
    partial class DebugPatchWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugPatchWindow));
            this.label_Progress = new System.Windows.Forms.Label();
            this.timer_Progress = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_Progress
            // 
            this.label_Progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Progress.Location = new System.Drawing.Point(0, 0);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(184, 61);
            this.label_Progress.TabIndex = 0;
            this.label_Progress.Text = "Patching Values...";
            this.label_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_Progress
            // 
            this.timer_Progress.Enabled = true;
            this.timer_Progress.Interval = 50;
            this.timer_Progress.Tick += new System.EventHandler(this.timer_Progress_Tick);
            // 
            // DebugPatchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 61);
            this.Controls.Add(this.label_Progress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DebugPatchWindow";
            this.Text = "Patching";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Progress;
        private System.Windows.Forms.Timer timer_Progress;
    }
}