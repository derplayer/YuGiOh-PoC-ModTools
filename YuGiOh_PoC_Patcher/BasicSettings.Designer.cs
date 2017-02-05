namespace YuGiOh_PoC_Patcher
{
    partial class BasicSettings
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
            this.checkBox_Bugfix = new System.Windows.Forms.CheckBox();
            this.checkBox_FPS = new System.Windows.Forms.CheckBox();
            this.checkBox_FPSCount = new System.Windows.Forms.CheckBox();
            this.checkBox_DisableSound = new System.Windows.Forms.CheckBox();
            this.comboBox_Language = new System.Windows.Forms.ComboBox();
            this.groupBox_Main = new System.Windows.Forms.GroupBox();
            this.radio32Bit = new System.Windows.Forms.RadioButton();
            this.groupBox_Graphic = new System.Windows.Forms.GroupBox();
            this.radioWindow = new System.Windows.Forms.RadioButton();
            this.radio16Bit = new System.Windows.Forms.RadioButton();
            this.radio24Bit = new System.Windows.Forms.RadioButton();
            this.groupBox_AI = new System.Windows.Forms.GroupBox();
            this.radioAI_H = new System.Windows.Forms.RadioButton();
            this.radioAI_E = new System.Windows.Forms.RadioButton();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox_Main.SuspendLayout();
            this.groupBox_Graphic.SuspendLayout();
            this.groupBox_AI.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_Bugfix
            // 
            this.checkBox_Bugfix.AutoSize = true;
            this.checkBox_Bugfix.Location = new System.Drawing.Point(6, 19);
            this.checkBox_Bugfix.Name = "checkBox_Bugfix";
            this.checkBox_Bugfix.Size = new System.Drawing.Size(134, 17);
            this.checkBox_Bugfix.TabIndex = 0;
            this.checkBox_Bugfix.Text = "Windows Vista+ Bugfix";
            this.checkBox_Bugfix.UseVisualStyleBackColor = true;
            // 
            // checkBox_FPS
            // 
            this.checkBox_FPS.AutoSize = true;
            this.checkBox_FPS.Location = new System.Drawing.Point(6, 44);
            this.checkBox_FPS.Name = "checkBox_FPS";
            this.checkBox_FPS.Size = new System.Drawing.Size(91, 17);
            this.checkBox_FPS.TabIndex = 1;
            this.checkBox_FPS.Text = "60 FPS Mode";
            this.checkBox_FPS.UseVisualStyleBackColor = true;
            // 
            // checkBox_FPSCount
            // 
            this.checkBox_FPSCount.AutoSize = true;
            this.checkBox_FPSCount.Location = new System.Drawing.Point(6, 68);
            this.checkBox_FPSCount.Name = "checkBox_FPSCount";
            this.checkBox_FPSCount.Size = new System.Drawing.Size(86, 17);
            this.checkBox_FPSCount.TabIndex = 2;
            this.checkBox_FPSCount.Text = "FPS Counter";
            this.checkBox_FPSCount.UseVisualStyleBackColor = true;
            // 
            // checkBox_DisableSound
            // 
            this.checkBox_DisableSound.AutoSize = true;
            this.checkBox_DisableSound.Location = new System.Drawing.Point(5, 91);
            this.checkBox_DisableSound.Name = "checkBox_DisableSound";
            this.checkBox_DisableSound.Size = new System.Drawing.Size(95, 17);
            this.checkBox_DisableSound.TabIndex = 5;
            this.checkBox_DisableSound.Text = "Disable Sound";
            this.checkBox_DisableSound.UseVisualStyleBackColor = true;
            // 
            // comboBox_Language
            // 
            this.comboBox_Language.FormattingEnabled = true;
            this.comboBox_Language.Location = new System.Drawing.Point(12, 291);
            this.comboBox_Language.Name = "comboBox_Language";
            this.comboBox_Language.Size = new System.Drawing.Size(183, 21);
            this.comboBox_Language.TabIndex = 10;
            this.comboBox_Language.Text = "Language";
            this.comboBox_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox_Main
            // 
            this.groupBox_Main.Controls.Add(this.checkBox_DisableSound);
            this.groupBox_Main.Controls.Add(this.checkBox_Bugfix);
            this.groupBox_Main.Controls.Add(this.checkBox_FPSCount);
            this.groupBox_Main.Controls.Add(this.checkBox_FPS);
            this.groupBox_Main.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Main.Name = "groupBox_Main";
            this.groupBox_Main.Size = new System.Drawing.Size(183, 116);
            this.groupBox_Main.TabIndex = 11;
            this.groupBox_Main.TabStop = false;
            this.groupBox_Main.Text = "Main Settings";
            // 
            // radio32Bit
            // 
            this.radio32Bit.AutoSize = true;
            this.radio32Bit.Location = new System.Drawing.Point(6, 23);
            this.radio32Bit.Name = "radio32Bit";
            this.radio32Bit.Size = new System.Drawing.Size(114, 17);
            this.radio32Bit.TabIndex = 12;
            this.radio32Bit.TabStop = true;
            this.radio32Bit.Text = "Full Screen (32-Bit)";
            this.radio32Bit.UseVisualStyleBackColor = true;
            // 
            // groupBox_Graphic
            // 
            this.groupBox_Graphic.Controls.Add(this.radioWindow);
            this.groupBox_Graphic.Controls.Add(this.radio16Bit);
            this.groupBox_Graphic.Controls.Add(this.radio24Bit);
            this.groupBox_Graphic.Controls.Add(this.radio32Bit);
            this.groupBox_Graphic.Location = new System.Drawing.Point(12, 134);
            this.groupBox_Graphic.Name = "groupBox_Graphic";
            this.groupBox_Graphic.Size = new System.Drawing.Size(121, 151);
            this.groupBox_Graphic.TabIndex = 13;
            this.groupBox_Graphic.TabStop = false;
            this.groupBox_Graphic.Text = "Graphic Settings";
            this.groupBox_Graphic.Enter += new System.EventHandler(this.groupBox_Graphic_Enter);
            // 
            // radioWindow
            // 
            this.radioWindow.AutoSize = true;
            this.radioWindow.Location = new System.Drawing.Point(6, 106);
            this.radioWindow.Name = "radioWindow";
            this.radioWindow.Size = new System.Drawing.Size(94, 17);
            this.radioWindow.TabIndex = 15;
            this.radioWindow.TabStop = true;
            this.radioWindow.Text = "Window Mode";
            this.radioWindow.UseVisualStyleBackColor = true;
            // 
            // radio16Bit
            // 
            this.radio16Bit.AutoSize = true;
            this.radio16Bit.Location = new System.Drawing.Point(5, 71);
            this.radio16Bit.Name = "radio16Bit";
            this.radio16Bit.Size = new System.Drawing.Size(114, 17);
            this.radio16Bit.TabIndex = 14;
            this.radio16Bit.TabStop = true;
            this.radio16Bit.Text = "Full Screen (16-Bit)";
            this.radio16Bit.UseVisualStyleBackColor = true;
            // 
            // radio24Bit
            // 
            this.radio24Bit.AutoSize = true;
            this.radio24Bit.Location = new System.Drawing.Point(6, 46);
            this.radio24Bit.Name = "radio24Bit";
            this.radio24Bit.Size = new System.Drawing.Size(114, 17);
            this.radio24Bit.TabIndex = 13;
            this.radio24Bit.TabStop = true;
            this.radio24Bit.Text = "Full Screen (24-Bit)";
            this.radio24Bit.UseVisualStyleBackColor = true;
            // 
            // groupBox_AI
            // 
            this.groupBox_AI.Controls.Add(this.radioAI_H);
            this.groupBox_AI.Controls.Add(this.radioAI_E);
            this.groupBox_AI.Location = new System.Drawing.Point(140, 134);
            this.groupBox_AI.Name = "groupBox_AI";
            this.groupBox_AI.Size = new System.Drawing.Size(55, 151);
            this.groupBox_AI.TabIndex = 14;
            this.groupBox_AI.TabStop = false;
            this.groupBox_AI.Text = "AI";
            // 
            // radioAI_H
            // 
            this.radioAI_H.AutoSize = true;
            this.radioAI_H.Location = new System.Drawing.Point(6, 90);
            this.radioAI_H.Name = "radioAI_H";
            this.radioAI_H.Size = new System.Drawing.Size(48, 17);
            this.radioAI_H.TabIndex = 1;
            this.radioAI_H.TabStop = true;
            this.radioAI_H.Text = "Hard";
            this.radioAI_H.UseVisualStyleBackColor = true;
            // 
            // radioAI_E
            // 
            this.radioAI_E.AutoSize = true;
            this.radioAI_E.Location = new System.Drawing.Point(6, 46);
            this.radioAI_E.Name = "radioAI_E";
            this.radioAI_E.Size = new System.Drawing.Size(48, 17);
            this.radioAI_E.TabIndex = 0;
            this.radioAI_E.TabStop = true;
            this.radioAI_E.Text = "Easy";
            this.radioAI_E.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(12, 318);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(183, 33);
            this.button_Save.TabIndex = 15;
            this.button_Save.Text = "Apply and Close";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button1_Click);
            // 
            // BasicSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 363);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox_AI);
            this.Controls.Add(this.groupBox_Graphic);
            this.Controls.Add(this.groupBox_Main);
            this.Controls.Add(this.comboBox_Language);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicSettings";
            this.Text = "Basic Settings";
            this.Load += new System.EventHandler(this.BasicSettings_Load);
            this.groupBox_Main.ResumeLayout(false);
            this.groupBox_Main.PerformLayout();
            this.groupBox_Graphic.ResumeLayout(false);
            this.groupBox_Graphic.PerformLayout();
            this.groupBox_AI.ResumeLayout(false);
            this.groupBox_AI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Bugfix;
        private System.Windows.Forms.CheckBox checkBox_FPS;
        private System.Windows.Forms.CheckBox checkBox_FPSCount;
        private System.Windows.Forms.CheckBox checkBox_DisableSound;
        private System.Windows.Forms.ComboBox comboBox_Language;
        private System.Windows.Forms.GroupBox groupBox_Main;
        private System.Windows.Forms.RadioButton radio32Bit;
        private System.Windows.Forms.GroupBox groupBox_Graphic;
        private System.Windows.Forms.RadioButton radioWindow;
        private System.Windows.Forms.RadioButton radio16Bit;
        private System.Windows.Forms.RadioButton radio24Bit;
        private System.Windows.Forms.GroupBox groupBox_AI;
        private System.Windows.Forms.RadioButton radioAI_H;
        private System.Windows.Forms.RadioButton radioAI_E;
        private System.Windows.Forms.Button button_Save;
    }
}