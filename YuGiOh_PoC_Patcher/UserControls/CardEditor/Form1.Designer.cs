
namespace WindowsFormsApp1
{
    partial class FormCardEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCardEdit));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyLinkToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFindNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReplace = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveFilter = new System.Windows.Forms.ToolStripButton();
            this.openFileDialogEHPunpack = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogEHPunpack = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogEHPpack = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogEHPpack = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogDBfolderOpen = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogDBfolderOpen = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogDBfolderPack = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogDBfolderPack = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabActions = new System.Windows.Forms.TabPage();
            this.hiraganaCheckBox = new System.Windows.Forms.CheckBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listView1 = new WindowsFormsApp1.ListViewEx();
            this.CardID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ATK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DEF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Attr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rarity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardExistFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDesc.SuspendLayout();
            this.tabActions.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "ehp";
            this.openFileDialog1.FileName = "cardinfo_eng";
            this.openFileDialog1.Filter = "CardInfo DB folder|CARD_Name_*.bin|All files|*.*";
            this.openFileDialog1.Title = "Open a CardInfo DB file/folder...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1180, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(582, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Welcome! Use \"File > Open\" to load a Card database.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Enabled = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(582, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLinkToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 26);
            // 
            // copyLinkToClipboardToolStripMenuItem
            // 
            this.copyLinkToClipboardToolStripMenuItem.Name = "copyLinkToClipboardToolStripMenuItem";
            this.copyLinkToClipboardToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.copyLinkToClipboardToolStripMenuItem.Text = "Copy link to clipboard...";
            this.copyLinkToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyLinkToClipboardToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "ehp";
            this.saveFileDialog1.Filter = "CardInfo DB folder|*.bin|All files|*.*";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBox1.Items.AddRange(new object[] {
            "Japanese",
            "English",
            "German",
            "French",
            "Italian",
            "Spanish"});
            this.comboBox1.Location = new System.Drawing.Point(1047, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(934, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Database &Language:";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(17, 17);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripButtonSaveAs,
            this.toolStripSeparator2,
            this.toolStripButtonFind,
            this.toolStripButtonFindNext,
            this.toolStripButtonReplace,
            this.toolStripSeparator3,
            this.toolStripButtonFilter,
            this.toolStripButtonRemoveFilter});
            this.toolStrip1.Location = new System.Drawing.Point(9, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(204, 30);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::YuGiOh_PoC_Patcher.Properties.Resources.load_result;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonOpen.Text = "Open...";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            this.toolStripButtonOpen.MouseEnter += new System.EventHandler(this.openToolStripMenuItem_MouseHover);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Enabled = false;
            this.toolStripButtonSave.Image = global::YuGiOh_PoC_Patcher.Properties.Resources.save_result;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            this.toolStripButtonSave.MouseEnter += new System.EventHandler(this.saveToolStripMenuItem_MouseHover);
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveAs.Enabled = false;
            this.toolStripButtonSaveAs.Image = global::YuGiOh_PoC_Patcher.Properties.Resources.saveas;
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonSaveAs.Text = "Save As...";
            this.toolStripButtonSaveAs.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            this.toolStripButtonSaveAs.MouseEnter += new System.EventHandler(this.saveAsToolStripMenuItem_MouseHover);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButtonFind
            // 
            this.toolStripButtonFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFind.Enabled = false;
            this.toolStripButtonFind.Image = global::YuGiOh_PoC_Patcher.Properties.Resources.search_result;
            this.toolStripButtonFind.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButtonFind.Name = "toolStripButtonFind";
            this.toolStripButtonFind.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonFind.Text = "Find...";
            this.toolStripButtonFind.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            this.toolStripButtonFind.MouseEnter += new System.EventHandler(this.findToolStripMenuItem_MouseHover);
            // 
            // toolStripButtonFindNext
            // 
            this.toolStripButtonFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFindNext.Enabled = false;
            this.toolStripButtonFindNext.Image = global::YuGiOh_PoC_Patcher.Properties.Resources.searchnext;
            this.toolStripButtonFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFindNext.Name = "toolStripButtonFindNext";
            this.toolStripButtonFindNext.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonFindNext.Text = "Find Next";
            this.toolStripButtonFindNext.Click += new System.EventHandler(this.findNextToolStripMenuItem_Click);
            this.toolStripButtonFindNext.MouseEnter += new System.EventHandler(this.findNextToolStripMenuItem_MouseHover);
            // 
            // toolStripButtonReplace
            // 
            this.toolStripButtonReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReplace.Enabled = false;
            this.toolStripButtonReplace.Image = global::YuGiOh_PoC_Patcher.Properties.Resources.search_replace;
            this.toolStripButtonReplace.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButtonReplace.Name = "toolStripButtonReplace";
            this.toolStripButtonReplace.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonReplace.Text = "Replace...";
            this.toolStripButtonReplace.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            this.toolStripButtonReplace.MouseEnter += new System.EventHandler(this.replaceToolStripMenuItem_MouseHover);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButtonFilter
            // 
            this.toolStripButtonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFilter.Enabled = false;
            this.toolStripButtonFilter.Image = global::YuGiOh_PoC_Patcher.Properties.Resources.narrowsearch_result;
            this.toolStripButtonFilter.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButtonFilter.Name = "toolStripButtonFilter";
            this.toolStripButtonFilter.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonFilter.Text = "Filter...";
            this.toolStripButtonFilter.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            this.toolStripButtonFilter.MouseEnter += new System.EventHandler(this.filterToolStripMenuItem_MouseHover);
            // 
            // toolStripButtonRemoveFilter
            // 
            this.toolStripButtonRemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveFilter.Enabled = false;
            this.toolStripButtonRemoveFilter.Image = global::YuGiOh_PoC_Patcher.Properties.Resources.resetnarrowsearch_result;
            this.toolStripButtonRemoveFilter.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButtonRemoveFilter.Name = "toolStripButtonRemoveFilter";
            this.toolStripButtonRemoveFilter.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonRemoveFilter.Text = "Remove filter";
            this.toolStripButtonRemoveFilter.Click += new System.EventHandler(this.removeFilterToolStripMenuItem_Click);
            this.toolStripButtonRemoveFilter.MouseEnter += new System.EventHandler(this.removeFilterToolStripMenuItem_MouseHover);
            // 
            // openFileDialogEHPunpack
            // 
            this.openFileDialogEHPunpack.DefaultExt = "ehp";
            this.openFileDialogEHPunpack.Filter = "EhFolder|*.ehp|All files|*.*";
            this.openFileDialogEHPunpack.Title = "Select an EhFolder to extract...";
            // 
            // saveFileDialogEHPunpack
            // 
            this.saveFileDialogEHPunpack.AddExtension = false;
            this.saveFileDialogEHPunpack.FileName = "Select a folder for output";
            this.saveFileDialogEHPunpack.OverwritePrompt = false;
            this.saveFileDialogEHPunpack.Title = "Select a folder for output...";
            this.saveFileDialogEHPunpack.ValidateNames = false;
            // 
            // openFileDialogEHPpack
            // 
            this.openFileDialogEHPpack.AddExtension = false;
            this.openFileDialogEHPpack.CheckFileExists = false;
            this.openFileDialogEHPpack.Filter = "All files|*.*";
            this.openFileDialogEHPpack.Title = "Select a folder (pick any file within the folder)...";
            this.openFileDialogEHPpack.ValidateNames = false;
            // 
            // saveFileDialogEHPpack
            // 
            this.saveFileDialogEHPpack.DefaultExt = "ehp";
            this.saveFileDialogEHPpack.Filter = "EhFolder|*.ehp|All files|*.*";
            this.saveFileDialogEHPpack.Title = "Select a filename for the EhFolder output...";
            // 
            // openFileDialogDBfolderOpen
            // 
            this.openFileDialogDBfolderOpen.DefaultExt = "bin";
            this.openFileDialogDBfolderOpen.FileName = "CARD_Name_E.bin";
            this.openFileDialogDBfolderOpen.Filter = "CardInfo DB folder|CARD_Name_*.bin|All files|*.*";
            this.openFileDialogDBfolderOpen.Title = "Select a folder containing the Card DB files...";
            // 
            // saveFileDialogDBfolderOpen
            // 
            this.saveFileDialogDBfolderOpen.DefaultExt = "ini";
            this.saveFileDialogDBfolderOpen.Filter = "CardInfo DB ini|*.ini|All files|*.*";
            // 
            // openFileDialogDBfolderPack
            // 
            this.openFileDialogDBfolderPack.DefaultExt = "ini";
            this.openFileDialogDBfolderPack.Filter = "CardInfo DB ini|*.ini|All files|*.*";
            this.openFileDialogDBfolderPack.Title = "Select a CardInfo DB ini file...";
            // 
            // saveFileDialogDBfolderPack
            // 
            this.saveFileDialogDBfolderPack.AddExtension = false;
            this.saveFileDialogDBfolderPack.FileName = "Select the output location for the CardInfo DB bin files";
            this.saveFileDialogDBfolderPack.OverwritePrompt = false;
            this.saveFileDialogDBfolderPack.Title = "Select the output location for the CardInfo DB bin files...";
            this.saveFileDialogDBfolderPack.ValidateNames = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 120;
            this.splitContainer1.Size = new System.Drawing.Size(1180, 499);
            this.splitContainer1.SplitterDistance = 881;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer2.Panel1MinSize = 120;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer2.Panel2MinSize = 120;
            this.splitContainer2.Size = new System.Drawing.Size(295, 499);
            this.splitContainer2.SplitterDistance = 223;
            this.splitContainer2.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDesc);
            this.tabControl1.Controls.Add(this.tabActions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(295, 223);
            this.tabControl1.TabIndex = 4;
            // 
            // tabDesc
            // 
            this.tabDesc.Controls.Add(this.label6);
            this.tabDesc.Controls.Add(this.label5);
            this.tabDesc.Controls.Add(this.label4);
            this.tabDesc.Controls.Add(this.label3);
            this.tabDesc.Controls.Add(this.label2);
            this.tabDesc.Controls.Add(this.label1);
            this.tabDesc.Controls.Add(this.textBox1);
            this.tabDesc.Location = new System.Drawing.Point(4, 22);
            this.tabDesc.Name = "tabDesc";
            this.tabDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesc.Size = new System.Drawing.Size(287, 197);
            this.tabDesc.TabIndex = 0;
            this.tabDesc.Text = "Description";
            this.tabDesc.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 162);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "39618799";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "[Fairy/Ritual/Effect]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Level: 8";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(220, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "LIGHT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ATK/ 2700 DEF/ 2400";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cyber Angel Dakini";
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(3, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(281, 106);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabActions
            // 
            this.tabActions.Controls.Add(this.hiraganaCheckBox);
            this.tabActions.Controls.Add(this.linkLabel2);
            this.tabActions.Controls.Add(this.linkLabel1);
            this.tabActions.Location = new System.Drawing.Point(4, 22);
            this.tabActions.Name = "tabActions";
            this.tabActions.Padding = new System.Windows.Forms.Padding(3);
            this.tabActions.Size = new System.Drawing.Size(287, 197);
            this.tabActions.TabIndex = 1;
            this.tabActions.Text = "Actions";
            this.tabActions.UseVisualStyleBackColor = true;
            // 
            // hiraganaCheckBox
            // 
            this.hiraganaCheckBox.AutoSize = true;
            this.hiraganaCheckBox.Enabled = false;
            this.hiraganaCheckBox.Location = new System.Drawing.Point(10, 49);
            this.hiraganaCheckBox.Name = "hiraganaCheckBox";
            this.hiraganaCheckBox.Size = new System.Drawing.Size(216, 17);
            this.hiraganaCheckBox.TabIndex = 2;
            this.hiraganaCheckBox.Text = "Show Hiragana subtext (unimplemented)";
            this.hiraganaCheckBox.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Enabled = false;
            this.linkLabel2.Location = new System.Drawing.Point(7, 28);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(210, 13);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Lookup card in Konami Card DB (by Name)";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            this.linkLabel2.MouseEnter += new System.EventHandler(this.linkLabel2_MouseEnter);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Enabled = false;
            this.linkLabel1.Location = new System.Drawing.Point(7, 7);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(215, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Lookup card in Konami Card DB (by CardID)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.MouseEnter += new System.EventHandler(this.linkLabel1_MouseEnter);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Enabled = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(295, 272);
            this.propertyGrid1.TabIndex = 3;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 30);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1180, 499);
            this.panelMain.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1180, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CardID,
            this.CardName,
            this.Kind,
            this.Level,
            this.ATK,
            this.DEF,
            this.Type,
            this.Attr,
            this.CardIcon,
            this.Rarity,
            this.Password,
            this.CardExistFlag,
            this.Description});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(881, 499);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // CardID
            // 
            this.CardID.Name = "CardID";
            this.CardID.Text = "ID";
            this.CardID.Width = 38;
            // 
            // CardName
            // 
            this.CardName.Name = "CardName";
            this.CardName.Text = "CardName";
            this.CardName.Width = 250;
            // 
            // Kind
            // 
            this.Kind.Name = "Kind";
            this.Kind.Text = "Kind";
            this.Kind.Width = 78;
            // 
            // Level
            // 
            this.Level.Name = "Level";
            this.Level.Text = "Level";
            this.Level.Width = 40;
            // 
            // ATK
            // 
            this.ATK.Name = "ATK";
            this.ATK.Text = "ATK";
            this.ATK.Width = 40;
            // 
            // DEF
            // 
            this.DEF.Name = "DEF";
            this.DEF.Text = "DEF";
            this.DEF.Width = 40;
            // 
            // Type
            // 
            this.Type.Name = "Type";
            this.Type.Text = "Type";
            this.Type.Width = 80;
            // 
            // Attr
            // 
            this.Attr.Name = "Attr";
            this.Attr.Text = "Attribute";
            // 
            // CardIcon
            // 
            this.CardIcon.Name = "CardIcon";
            this.CardIcon.Text = "CardIcon";
            this.CardIcon.Width = 66;
            // 
            // Rarity
            // 
            this.Rarity.Name = "Rarity";
            this.Rarity.Text = "Rarity";
            this.Rarity.Width = 76;
            // 
            // Password
            // 
            this.Password.Name = "Password";
            this.Password.Text = "Password";
            // 
            // CardExistFlag
            // 
            this.CardExistFlag.Name = "CardExistFlag";
            this.CardExistFlag.Text = "CardExist";
            this.CardExistFlag.Width = 62;
            // 
            // Description
            // 
            this.Description.Name = "Description";
            this.Description.Text = "Description";
            this.Description.Width = 120;
            // 
            // FormCardEdit
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 551);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(693, 448);
            this.Name = "FormCardEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power of Chaos CardInfo Editor GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            this.tabActions.ResumeLayout(false);
            this.tabActions.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyLinkToClipboardToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonFind;
        private System.Windows.Forms.ToolStripButton toolStripButtonFindNext;
        private System.Windows.Forms.ToolStripButton toolStripButtonReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonFilter;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveFilter;
        private System.Windows.Forms.ColumnHeader olvColumnCardID;
        private System.Windows.Forms.ColumnHeader olvColumnName;
        private System.Windows.Forms.ColumnHeader olvColumnKind;
        private System.Windows.Forms.ColumnHeader olvColumnLevel;
        private System.Windows.Forms.ColumnHeader olvColumnATK;
        private System.Windows.Forms.ColumnHeader olvColumnDEF;
        private System.Windows.Forms.ColumnHeader olvColumnType;
        private System.Windows.Forms.ColumnHeader olvColumnAttrib;
        private System.Windows.Forms.ColumnHeader olvColumnIcon;
        private System.Windows.Forms.ColumnHeader olvColumnRarity;
        private System.Windows.Forms.ColumnHeader olvColumnPassword;
        private System.Windows.Forms.ColumnHeader olvColumnCardExists;
        private System.Windows.Forms.ColumnHeader olvColumnDescr;
        private System.Windows.Forms.OpenFileDialog openFileDialogEHPunpack;
        private System.Windows.Forms.SaveFileDialog saveFileDialogEHPunpack;
        private System.Windows.Forms.OpenFileDialog openFileDialogEHPpack;
        private System.Windows.Forms.SaveFileDialog saveFileDialogEHPpack;
        private System.Windows.Forms.OpenFileDialog openFileDialogDBfolderOpen;
        private System.Windows.Forms.SaveFileDialog saveFileDialogDBfolderOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialogDBfolderPack;
        private System.Windows.Forms.SaveFileDialog saveFileDialogDBfolderPack;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabActions;
        private System.Windows.Forms.CheckBox hiraganaCheckBox;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panelMain;
        private ListViewEx listView1;
        private System.Windows.Forms.ColumnHeader CardID;
        private System.Windows.Forms.ColumnHeader CardName;
        private System.Windows.Forms.ColumnHeader Kind;
        private System.Windows.Forms.ColumnHeader Level;
        private System.Windows.Forms.ColumnHeader ATK;
        private System.Windows.Forms.ColumnHeader DEF;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Attr;
        private System.Windows.Forms.ColumnHeader CardIcon;
        private System.Windows.Forms.ColumnHeader Rarity;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ColumnHeader CardExistFlag;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

