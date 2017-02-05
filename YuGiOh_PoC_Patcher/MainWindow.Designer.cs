namespace YuGiOh_PoC_Patcher
{
    partial class MainWindow
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
            System.Windows.Forms.TabPage tabPage3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dankYGAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dankToYGAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lZZSToDankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkEmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_Rotate = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Browse = new System.Windows.Forms.Button();
            this.button_Apply = new System.Windows.Forms.Button();
            this.textBox_FieldBackground = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Player = new System.Windows.Forms.TabPage();
            this.fieldUserControl_Player = new YuGiOh_PoC_Patcher.FieldUserControl();
            this.tabPage_Enemy = new System.Windows.Forms.TabPage();
            this.fieldUserControl_Enemy = new YuGiOh_PoC_Patcher.FieldUserControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pointUserControl_WindowSize = new YuGiOh_PoC_Patcher.PointUserControl();
            this.groupBox_CardSize = new System.Windows.Forms.GroupBox();
            this.label_CardSize_Width = new System.Windows.Forms.Label();
            this.label_CardSize_Height = new System.Windows.Forms.Label();
            this.numericUpDown_CardSize_Width = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CardSize_Height = new System.Windows.Forms.NumericUpDown();
            this.button_Patch = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_Preview = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            tabPage3 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage_Player.SuspendLayout();
            this.tabPage_Enemy.SuspendLayout();
            tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_CardSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CardSize_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CardSize_Height)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.convertToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1146, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openToolStripMenuItem.Text = "Open Patch Template";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.saveToolStripMenuItem.Text = "Save Patch Template";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dankYGAToolStripMenuItem,
            this.dankToYGAToolStripMenuItem,
            this.lZZSToDankToolStripMenuItem});
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.convertToolStripMenuItem.Text = "Convert";
            // 
            // dankYGAToolStripMenuItem
            // 
            this.dankYGAToolStripMenuItem.Name = "dankYGAToolStripMenuItem";
            this.dankYGAToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.dankYGAToolStripMenuItem.Text = "YGA ➯ PNG";
            this.dankYGAToolStripMenuItem.Click += new System.EventHandler(this.dankYGAToolStripMenuItem_Click_1);
            // 
            // dankToYGAToolStripMenuItem
            // 
            this.dankToYGAToolStripMenuItem.Name = "dankToYGAToolStripMenuItem";
            this.dankToYGAToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.dankToYGAToolStripMenuItem.Text = "PNG ➯ YGA";
            this.dankToYGAToolStripMenuItem.Click += new System.EventHandler(this.dankToYGAToolStripMenuItem_Click_1);
            // 
            // lZZSToDankToolStripMenuItem
            // 
            this.lZZSToDankToolStripMenuItem.Name = "lZZSToDankToolStripMenuItem";
            this.lZZSToDankToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.lZZSToDankToolStripMenuItem.Text = "\"LZSS\" Decompress";
            this.lZZSToDankToolStripMenuItem.Click += new System.EventHandler(this.lZZSToDankToolStripMenuItem_Click_1);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateImagesToolStripMenuItem,
            this.checkEmToolStripMenuItem,
            this.testToolStripMenuItem});
            this.debugToolStripMenuItem.Enabled = false;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // generateImagesToolStripMenuItem
            // 
            this.generateImagesToolStripMenuItem.Name = "generateImagesToolStripMenuItem";
            this.generateImagesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.generateImagesToolStripMenuItem.Text = "Generate Images";
            this.generateImagesToolStripMenuItem.Click += new System.EventHandler(this.generateImagesToolStripMenuItem_Click);
            // 
            // checkEmToolStripMenuItem
            // 
            this.checkEmToolStripMenuItem.Name = "checkEmToolStripMenuItem";
            this.checkEmToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.checkEmToolStripMenuItem.Text = "Check em";
            this.checkEmToolStripMenuItem.Click += new System.EventHandler(this.checkEmToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // checkBox_Rotate
            // 
            this.checkBox_Rotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Rotate.AutoSize = true;
            this.checkBox_Rotate.Location = new System.Drawing.Point(1063, 4);
            this.checkBox_Rotate.Name = "checkBox_Rotate";
            this.checkBox_Rotate.Size = new System.Drawing.Size(83, 17);
            this.checkBox_Rotate.TabIndex = 23;
            this.checkBox_Rotate.Text = "Rotate Card";
            this.checkBox_Rotate.UseVisualStyleBackColor = true;
            this.checkBox_Rotate.CheckedChanged += new System.EventHandler(this.checkBox_Rotate_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.pointUserControl_WindowSize);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_CardSize);
            this.splitContainer1.Panel1.Controls.Add(this.button_Patch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1146, 607);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 155);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(322, 449);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button_Browse);
            this.tabPage2.Controls.Add(this.button_Apply);
            this.tabPage2.Controls.Add(this.textBox_FieldBackground);
            this.tabPage2.Controls.Add(this.tabControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(314, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Duel Field";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Field Background:";
            // 
            // button_Browse
            // 
            this.button_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Browse.Location = new System.Drawing.Point(220, 12);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(26, 22);
            this.button_Browse.TabIndex = 18;
            this.button_Browse.Text = "...";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // button_Apply
            // 
            this.button_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Apply.Location = new System.Drawing.Point(252, 12);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(54, 23);
            this.button_Apply.TabIndex = 17;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // textBox_FieldBackground
            // 
            this.textBox_FieldBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FieldBackground.Location = new System.Drawing.Point(102, 13);
            this.textBox_FieldBackground.Name = "textBox_FieldBackground";
            this.textBox_FieldBackground.Size = new System.Drawing.Size(112, 20);
            this.textBox_FieldBackground.TabIndex = 16;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage_Player);
            this.tabControl.Controls.Add(this.tabPage_Enemy);
            this.tabControl.Location = new System.Drawing.Point(3, 53);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(308, 367);
            this.tabControl.TabIndex = 15;
            // 
            // tabPage_Player
            // 
            this.tabPage_Player.Controls.Add(this.fieldUserControl_Player);
            this.tabPage_Player.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Player.Name = "tabPage_Player";
            this.tabPage_Player.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Player.Size = new System.Drawing.Size(300, 341);
            this.tabPage_Player.TabIndex = 2;
            this.tabPage_Player.Text = "Player Field";
            this.tabPage_Player.UseVisualStyleBackColor = true;
            // 
            // fieldUserControl_Player
            // 
            this.fieldUserControl_Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldUserControl_Player.Field = null;
            this.fieldUserControl_Player.Location = new System.Drawing.Point(3, 3);
            this.fieldUserControl_Player.Name = "fieldUserControl_Player";
            this.fieldUserControl_Player.Size = new System.Drawing.Size(294, 335);
            this.fieldUserControl_Player.TabIndex = 0;
            // 
            // tabPage_Enemy
            // 
            this.tabPage_Enemy.Controls.Add(this.fieldUserControl_Enemy);
            this.tabPage_Enemy.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Enemy.Name = "tabPage_Enemy";
            this.tabPage_Enemy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Enemy.Size = new System.Drawing.Size(300, 341);
            this.tabPage_Enemy.TabIndex = 3;
            this.tabPage_Enemy.Text = "Enemy Field";
            this.tabPage_Enemy.UseVisualStyleBackColor = true;
            // 
            // fieldUserControl_Enemy
            // 
            this.fieldUserControl_Enemy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldUserControl_Enemy.Field = null;
            this.fieldUserControl_Enemy.Location = new System.Drawing.Point(3, 3);
            this.fieldUserControl_Enemy.Name = "fieldUserControl_Enemy";
            this.fieldUserControl_Enemy.Size = new System.Drawing.Size(294, 335);
            this.fieldUserControl_Enemy.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(this.label2);
            tabPage3.Location = new System.Drawing.Point(4, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new System.Windows.Forms.Padding(3);
            tabPage3.Size = new System.Drawing.Size(314, 423);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Deck Editor";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.No;
            this.tabPage1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(314, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pointUserControl_WindowSize
            // 
            this.pointUserControl_WindowSize.Location = new System.Drawing.Point(8, 74);
            this.pointUserControl_WindowSize.Name = "pointUserControl_WindowSize";
            this.pointUserControl_WindowSize.Point = null;
            this.pointUserControl_WindowSize.Size = new System.Drawing.Size(146, 75);
            this.pointUserControl_WindowSize.TabIndex = 24;
            // 
            // groupBox_CardSize
            // 
            this.groupBox_CardSize.Controls.Add(this.label_CardSize_Width);
            this.groupBox_CardSize.Controls.Add(this.label_CardSize_Height);
            this.groupBox_CardSize.Controls.Add(this.numericUpDown_CardSize_Width);
            this.groupBox_CardSize.Controls.Add(this.numericUpDown_CardSize_Height);
            this.groupBox_CardSize.Location = new System.Drawing.Point(182, 74);
            this.groupBox_CardSize.Name = "groupBox_CardSize";
            this.groupBox_CardSize.Size = new System.Drawing.Size(140, 75);
            this.groupBox_CardSize.TabIndex = 20;
            this.groupBox_CardSize.TabStop = false;
            this.groupBox_CardSize.Text = "Card Size (for Preview)";
            // 
            // label_CardSize_Width
            // 
            this.label_CardSize_Width.AutoSize = true;
            this.label_CardSize_Width.Location = new System.Drawing.Point(22, 21);
            this.label_CardSize_Width.Name = "label_CardSize_Width";
            this.label_CardSize_Width.Size = new System.Drawing.Size(38, 13);
            this.label_CardSize_Width.TabIndex = 18;
            this.label_CardSize_Width.Text = "Width:";
            // 
            // label_CardSize_Height
            // 
            this.label_CardSize_Height.AutoSize = true;
            this.label_CardSize_Height.Location = new System.Drawing.Point(20, 47);
            this.label_CardSize_Height.Name = "label_CardSize_Height";
            this.label_CardSize_Height.Size = new System.Drawing.Size(41, 13);
            this.label_CardSize_Height.TabIndex = 19;
            this.label_CardSize_Height.Text = "Height:";
            // 
            // numericUpDown_CardSize_Width
            // 
            this.numericUpDown_CardSize_Width.Location = new System.Drawing.Point(66, 19);
            this.numericUpDown_CardSize_Width.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_CardSize_Width.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericUpDown_CardSize_Width.Name = "numericUpDown_CardSize_Width";
            this.numericUpDown_CardSize_Width.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown_CardSize_Width.TabIndex = 16;
            this.numericUpDown_CardSize_Width.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDown_CardSize_Height
            // 
            this.numericUpDown_CardSize_Height.Location = new System.Drawing.Point(66, 45);
            this.numericUpDown_CardSize_Height.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_CardSize_Height.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericUpDown_CardSize_Height.Name = "numericUpDown_CardSize_Height";
            this.numericUpDown_CardSize_Height.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown_CardSize_Height.TabIndex = 17;
            this.numericUpDown_CardSize_Height.Value = new decimal(new int[] {
            72,
            0,
            0,
            0});
            // 
            // button_Patch
            // 
            this.button_Patch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Patch.Location = new System.Drawing.Point(8, 10);
            this.button_Patch.Name = "button_Patch";
            this.button_Patch.Size = new System.Drawing.Size(314, 56);
            this.button_Patch.TabIndex = 0;
            this.button_Patch.Text = "Patch";
            this.button_Patch.UseVisualStyleBackColor = true;
            this.button_Patch.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(814, 607);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.pictureBox_Preview);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 114);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox_Preview
            // 
            this.pictureBox_Preview.Location = new System.Drawing.Point(3, -3);
            this.pictureBox_Preview.Name = "pictureBox_Preview";
            this.pictureBox_Preview.Size = new System.Drawing.Size(146, 114);
            this.pictureBox_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Preview.TabIndex = 0;
            this.pictureBox_Preview.TabStop = false;
            this.pictureBox_Preview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Preview_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Coming in next update!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Coming in next update!";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 634);
            this.Controls.Add(this.checkBox_Rotate);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Yu-Gi-Oh Power of Chaos - Patcher";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage_Player.ResumeLayout(false);
            this.tabPage_Enemy.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox_CardSize.ResumeLayout(false);
            this.groupBox_CardSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CardSize_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CardSize_Height)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Patch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox_Preview;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label label_CardSize_Height;
        private System.Windows.Forms.Label label_CardSize_Width;
        private System.Windows.Forms.NumericUpDown numericUpDown_CardSize_Height;
        private System.Windows.Forms.NumericUpDown numericUpDown_CardSize_Width;
        private System.Windows.Forms.GroupBox groupBox_CardSize;
        private System.Windows.Forms.CheckBox checkBox_Rotate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateImagesToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_Player;
        private System.Windows.Forms.TabPage tabPage_Enemy;
        private FieldUserControl fieldUserControl_Player;
        private FieldUserControl fieldUserControl_Enemy;
        private System.Windows.Forms.Panel panel1;
        private PointUserControl pointUserControl_WindowSize;
        private System.Windows.Forms.ToolStripMenuItem checkEmToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.TextBox textBox_FieldBackground;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dankYGAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dankToYGAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lZZSToDankToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

