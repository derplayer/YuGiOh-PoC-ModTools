using YuGiOh_PoC_Patcher.CustomControls;
using System.Drawing;

namespace YuGiOh_PoC_Patcher
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.ctlModernBlack1 = new jSkin.ctlModernBlack();
            this.linkLabel_ThePage = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_ChangePath = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Button_Settings = new YuGiOh_PoC_Patcher.CustomControls.RoundButton();
            this.Button_ModLauncher = new YuGiOh_PoC_Patcher.CustomControls.RoundButton();
            this.button1 = new YuGiOh_PoC_Patcher.CustomControls.RoundButton();
            this.Button_Exit = new YuGiOh_PoC_Patcher.CustomControls.RoundButton();
            this.Button_Game = new YuGiOh_PoC_Patcher.CustomControls.RoundButton();
            this.ctlModernBlack1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlModernBlack1
            // 
            this.ctlModernBlack1.Controls.Add(this.linkLabel_ThePage);
            this.ctlModernBlack1.Controls.Add(this.label1);
            this.ctlModernBlack1.Controls.Add(this.Button_ChangePath);
            this.ctlModernBlack1.Controls.Add(this.Button_Settings);
            this.ctlModernBlack1.Controls.Add(this.Button_ModLauncher);
            this.ctlModernBlack1.Controls.Add(this.button1);
            this.ctlModernBlack1.Controls.Add(this.Button_Exit);
            this.ctlModernBlack1.Controls.Add(this.Button_Game);
            this.ctlModernBlack1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlModernBlack1.FixedSingle = true;
            this.ctlModernBlack1.Location = new System.Drawing.Point(0, 0);
            this.ctlModernBlack1.Name = "ctlModernBlack1";
            this.ctlModernBlack1.Size = new System.Drawing.Size(419, 498);
            this.ctlModernBlack1.Stretch = false;
            this.ctlModernBlack1.TabIndex = 0;
            this.ctlModernBlack1.Load += new System.EventHandler(this.ctlModernBlack1_Load);
            // 
            // linkLabel_ThePage
            // 
            this.linkLabel_ThePage.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel_ThePage.AutoSize = true;
            this.linkLabel_ThePage.BackColor = System.Drawing.SystemColors.Window;
            this.linkLabel_ThePage.Location = new System.Drawing.Point(308, 474);
            this.linkLabel_ThePage.Name = "linkLabel_ThePage";
            this.linkLabel_ThePage.Size = new System.Drawing.Size(99, 13);
            this.linkLabel_ThePage.TabIndex = 7;
            this.linkLabel_ThePage.TabStop = true;
            this.linkLabel_ThePage.Text = "http://derplayer.xyz";
            this.linkLabel_ThePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_ThePage_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "By PhilYeahz && DerPlayer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Button_ChangePath
            // 
            this.Button_ChangePath.Location = new System.Drawing.Point(346, 52);
            this.Button_ChangePath.Name = "Button_ChangePath";
            this.Button_ChangePath.Size = new System.Drawing.Size(52, 47);
            this.Button_ChangePath.TabIndex = 5;
            this.Button_ChangePath.Text = "Change Game Path";
            this.Button_ChangePath.UseVisualStyleBackColor = true;
            this.Button_ChangePath.Click += new System.EventHandler(this.Button_ChangePath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Button_Settings
            // 
            this.Button_Settings.BackColor = System.Drawing.SystemColors.Control;
            this.Button_Settings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Settings.Location = new System.Drawing.Point(12, 321);
            this.Button_Settings.Name = "Button_Settings";
            this.Button_Settings.Size = new System.Drawing.Size(395, 60);
            this.Button_Settings.TabIndex = 3;
            this.Button_Settings.Text = "Advanced Settings (+Mod Tools)";
            this.Button_Settings.UseVisualStyleBackColor = true;
            this.Button_Settings.Click += new System.EventHandler(this.Button_Settings_Click);
            // 
            // Button_ModLauncher
            // 
            this.Button_ModLauncher.Location = new System.Drawing.Point(12, 139);
            this.Button_ModLauncher.Name = "Button_ModLauncher";
            this.Button_ModLauncher.Size = new System.Drawing.Size(395, 60);
            this.Button_ModLauncher.TabIndex = 1;
            this.Button_ModLauncher.Text = "Mod Selector";
            this.Button_ModLauncher.UseVisualStyleBackColor = true;
            this.Button_ModLauncher.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(395, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "Base Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.BackColor = System.Drawing.Color.White;
            this.Button_Exit.Location = new System.Drawing.Point(12, 411);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(395, 60);
            this.Button_Exit.TabIndex = 2;
            this.Button_Exit.Text = "Exit";
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.button4_Click);
            // 
            // Button_Game
            // 
            this.Button_Game.Location = new System.Drawing.Point(12, 45);
            this.Button_Game.Name = "Button_Game";
            this.Button_Game.Size = new System.Drawing.Size(395, 60);
            this.Button_Game.TabIndex = 0;
            this.Button_Game.Text = "Launch/Start";
            this.Button_Game.UseVisualStyleBackColor = true;
            this.Button_Game.Click += new System.EventHandler(this.Button_Game_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 498);
            this.Controls.Add(this.ctlModernBlack1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Yu-Gi-Ph Power of Chaos Mod Launcher v";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ctlModernBlack1.ResumeLayout(false);
            this.ctlModernBlack1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Button_ChangePath;
        private jSkin.ctlModernBlack ctlModernBlack1;
        private RoundButton Button_Settings;
        private RoundButton Button_Game;
        private RoundButton Button_ModLauncher;
        private RoundButton Button_Exit;
        private RoundButton button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel_ThePage;
    }
}