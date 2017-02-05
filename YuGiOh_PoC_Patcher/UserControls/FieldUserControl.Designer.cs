namespace YuGiOh_PoC_Patcher
{
    partial class FieldUserControl
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pointUserControl_Hand = new YuGiOh_PoC_Patcher.PointUserControl();
            this.pointUserControl_RemovedFromGame = new YuGiOh_PoC_Patcher.PointUserControl();
            this.pointUserControl_Deck = new YuGiOh_PoC_Patcher.PointUserControl();
            this.pointUserControl_Graveyard = new YuGiOh_PoC_Patcher.PointUserControl();
            this.pointUserControl_Fusion = new YuGiOh_PoC_Patcher.PointUserControl();
            this.pointUserControl_FieldEffect = new YuGiOh_PoC_Patcher.PointUserControl();
            this.pointBundleUserControl_MonsterCards = new YuGiOh_PoC_Patcher.UserControls.PointBundleUserControl();
            this.pointBundleUserControl_MagicCards = new YuGiOh_PoC_Patcher.UserControls.PointBundleUserControl();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.pointUserControl_Hand);
            this.flowLayoutPanel.Controls.Add(this.pointUserControl_RemovedFromGame);
            this.flowLayoutPanel.Controls.Add(this.pointUserControl_Deck);
            this.flowLayoutPanel.Controls.Add(this.pointUserControl_Graveyard);
            this.flowLayoutPanel.Controls.Add(this.pointUserControl_Fusion);
            this.flowLayoutPanel.Controls.Add(this.pointUserControl_FieldEffect);
            this.flowLayoutPanel.Controls.Add(this.pointBundleUserControl_MonsterCards);
            this.flowLayoutPanel.Controls.Add(this.pointBundleUserControl_MagicCards);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(288, 425);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // pointUserControl_Hand
            // 
            this.pointUserControl_Hand.Location = new System.Drawing.Point(3, 3);
            this.pointUserControl_Hand.Name = "pointUserControl_Hand";
            this.pointUserControl_Hand.Point = null;
            this.pointUserControl_Hand.Size = new System.Drawing.Size(125, 80);
            this.pointUserControl_Hand.TabIndex = 0;
            // 
            // pointUserControl_RemovedFromGame
            // 
            this.pointUserControl_RemovedFromGame.Location = new System.Drawing.Point(134, 3);
            this.pointUserControl_RemovedFromGame.Name = "pointUserControl_RemovedFromGame";
            this.pointUserControl_RemovedFromGame.Point = null;
            this.pointUserControl_RemovedFromGame.Size = new System.Drawing.Size(125, 80);
            this.pointUserControl_RemovedFromGame.TabIndex = 1;
            // 
            // pointUserControl_Deck
            // 
            this.pointUserControl_Deck.Location = new System.Drawing.Point(3, 89);
            this.pointUserControl_Deck.Name = "pointUserControl_Deck";
            this.pointUserControl_Deck.Point = null;
            this.pointUserControl_Deck.Size = new System.Drawing.Size(125, 80);
            this.pointUserControl_Deck.TabIndex = 2;
            // 
            // pointUserControl_Graveyard
            // 
            this.pointUserControl_Graveyard.Location = new System.Drawing.Point(134, 89);
            this.pointUserControl_Graveyard.Name = "pointUserControl_Graveyard";
            this.pointUserControl_Graveyard.Point = null;
            this.pointUserControl_Graveyard.Size = new System.Drawing.Size(125, 80);
            this.pointUserControl_Graveyard.TabIndex = 3;
            // 
            // pointUserControl_Fusion
            // 
            this.pointUserControl_Fusion.Location = new System.Drawing.Point(3, 175);
            this.pointUserControl_Fusion.Name = "pointUserControl_Fusion";
            this.pointUserControl_Fusion.Point = null;
            this.pointUserControl_Fusion.Size = new System.Drawing.Size(125, 80);
            this.pointUserControl_Fusion.TabIndex = 4;
            // 
            // pointUserControl_FieldEffect
            // 
            this.pointUserControl_FieldEffect.Location = new System.Drawing.Point(134, 175);
            this.pointUserControl_FieldEffect.Name = "pointUserControl_FieldEffect";
            this.pointUserControl_FieldEffect.Point = null;
            this.pointUserControl_FieldEffect.Size = new System.Drawing.Size(125, 80);
            this.pointUserControl_FieldEffect.TabIndex = 5;
            // 
            // pointBundleUserControl_MonsterCards
            // 
            this.pointBundleUserControl_MonsterCards.Location = new System.Drawing.Point(3, 261);
            this.pointBundleUserControl_MonsterCards.Name = "pointBundleUserControl_MonsterCards";
            this.pointBundleUserControl_MonsterCards.PointBundle = null;
            this.pointBundleUserControl_MonsterCards.Size = new System.Drawing.Size(125, 109);
            this.pointBundleUserControl_MonsterCards.TabIndex = 6;
            // 
            // pointBundleUserControl_MagicCards
            // 
            this.pointBundleUserControl_MagicCards.Location = new System.Drawing.Point(134, 261);
            this.pointBundleUserControl_MagicCards.Name = "pointBundleUserControl_MagicCards";
            this.pointBundleUserControl_MagicCards.PointBundle = null;
            this.pointBundleUserControl_MagicCards.Size = new System.Drawing.Size(125, 109);
            this.pointBundleUserControl_MagicCards.TabIndex = 7;
            // 
            // FieldUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "FieldUserControl";
            this.Size = new System.Drawing.Size(288, 425);
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PointUserControl pointUserControl_Hand;
        private PointUserControl pointUserControl_RemovedFromGame;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private PointUserControl pointUserControl_Deck;
        private PointUserControl pointUserControl_Graveyard;
        private PointUserControl pointUserControl_Fusion;
        private PointUserControl pointUserControl_FieldEffect;
        private UserControls.PointBundleUserControl pointBundleUserControl_MonsterCards;
        private UserControls.PointBundleUserControl pointBundleUserControl_MagicCards;
    }
}
