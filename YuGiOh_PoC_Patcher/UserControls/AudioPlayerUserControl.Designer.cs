namespace YuGiOh_PoC_Patcher.UserControls
{
    partial class AudioPlayerUserControl
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
            this.button_AudioPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_AudioPlay
            // 
            this.button_AudioPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AudioPlay.Location = new System.Drawing.Point(3, 3);
            this.button_AudioPlay.Name = "button_AudioPlay";
            this.button_AudioPlay.Size = new System.Drawing.Size(467, 58);
            this.button_AudioPlay.TabIndex = 2;
            this.button_AudioPlay.Text = "Play";
            this.button_AudioPlay.UseVisualStyleBackColor = true;
            // 
            // AudioPlayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_AudioPlay);
            this.Name = "AudioPlayerUserControl";
            this.Size = new System.Drawing.Size(473, 64);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_AudioPlay;
    }
}
