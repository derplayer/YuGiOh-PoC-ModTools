namespace jSkin{
    partial class ctlModernBlack
    {
        /// <summary> 
        /// ching chong nip nong
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlModernBlack));
            this.pButtons = new System.Windows.Forms.PictureBox();
            this.pLayout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLayout)).BeginInit();
            this.SuspendLayout();
            // 
            // pButtons
            // 
            this.pButtons.Image = ((System.Drawing.Image)(resources.GetObject("pButtons.Image")));
            this.pButtons.Location = new System.Drawing.Point(82, 0);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(105, 105);
            this.pButtons.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pButtons.TabIndex = 1;
            this.pButtons.TabStop = false;
            this.pButtons.Visible = false;
            // 
            // pLayout
            // 
            this.pLayout.Image = ((System.Drawing.Image)(resources.GetObject("pLayout.Image")));
            this.pLayout.Location = new System.Drawing.Point(0, 0);
            this.pLayout.Name = "pLayout";
            this.pLayout.Size = new System.Drawing.Size(64, 64);
            this.pLayout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pLayout.TabIndex = 0;
            this.pLayout.TabStop = false;
            this.pLayout.Visible = false;
            // 
            // ctlModernBlack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.pLayout);
            this.DoubleBuffered = true;
            this.Name = "ctlModernBlack";
            this.Size = new System.Drawing.Size(220, 151);
            this.Load += new System.EventHandler(this.ctlModernBlack_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ctlSkin_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ctlSkin_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctlSkin_MouseDown);
            this.MouseLeave += new System.EventHandler(this.ctlSkin_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctlSkin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctlSkin_MouseUp);
            this.Resize += new System.EventHandler(this.ctlSkin_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLayout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pLayout;
        private System.Windows.Forms.PictureBox pButtons;
    }
}