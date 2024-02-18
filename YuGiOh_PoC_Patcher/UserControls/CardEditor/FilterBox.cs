using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FilterBox : Form
    {
        public CardFilterParams cardFilterParams;

        public FilterBox()
        {
            InitializeComponent();
            cardFilterParams = new CardFilterParams();
            cardFilterParams.CardExists = true;
        }

        void SaveFilters()
        {
            // page 1 - typables
            cardFilterParams.Name = textBoxName.Text;
            if (!string.IsNullOrEmpty(fastTextBoxIDmin.Text))
                cardFilterParams.MinCardID = Int32.Parse(fastTextBoxIDmin.Text);
            else
                cardFilterParams.MinCardID = -1;
            if (!string.IsNullOrEmpty(fastTextBoxIDmax.Text))
                cardFilterParams.MaxCardID = Int32.Parse(fastTextBoxIDmax.Text);
            else
                cardFilterParams.MaxCardID = -1;
            if (!string.IsNullOrEmpty(fastTextBoxATKmin.Text))
                cardFilterParams.MinATK = Int32.Parse(fastTextBoxATKmin.Text);
            else
                cardFilterParams.MinATK = -1;
            if (!string.IsNullOrEmpty(fastTextBoxATKmax.Text))
                cardFilterParams.MaxATK = Int32.Parse(fastTextBoxATKmax.Text);
            else
                cardFilterParams.MaxATK = -1;
            if (!string.IsNullOrEmpty(fastTextBoxDEFmin.Text))
                cardFilterParams.MinDEF = Int32.Parse(fastTextBoxDEFmin.Text);
            else
                cardFilterParams.MinDEF = -1;
            if (!string.IsNullOrEmpty(fastTextBoxDEFmax.Text))
                cardFilterParams.MaxDEF = Int32.Parse(fastTextBoxDEFmax.Text);
            else
                cardFilterParams.MaxDEF = -1;
            if (!string.IsNullOrEmpty(fastTextBoxPassMin.Text))
                cardFilterParams.MinPassword = Int32.Parse(fastTextBoxPassMin.Text);
            else
                cardFilterParams.MinPassword = -1;
            if (!string.IsNullOrEmpty(fastTextBoxPassMax.Text))
                cardFilterParams.MaxPassword = Int32.Parse(fastTextBoxPassMax.Text);
            else
                cardFilterParams.MaxPassword = -1;
            if (!string.IsNullOrEmpty(fastTextBoxLVmin.Text))
                cardFilterParams.MinLevel = Int32.Parse(fastTextBoxLVmin.Text);
            else
                cardFilterParams.MinLevel = -1;
            if (!string.IsNullOrEmpty(fastTextBoxLVmax.Text))
                cardFilterParams.MaxLevel = Int32.Parse(fastTextBoxLVmax.Text);
            else
                cardFilterParams.MaxLevel = -1;

            cardFilterParams.MatchCase = checkBoxCase.Checked;
            cardFilterParams.MatchExact = checkBoxMatch.Checked;

            // page 2  - kinds
            cardFilterParams.Kind[(int)CardKinds.Normal] = checkBoxKindNormal.Checked;
            cardFilterParams.Kind[(int)CardKinds.Effect] = checkBoxKindEffect.Checked;
            cardFilterParams.Kind[(int)CardKinds.Fusion] = checkBoxKindFusion.Checked;
            //cardFilterParams.Kind[(int)CardKinds.FusionEffect] = checkBoxKindFusionEffect.Checked;
            cardFilterParams.Kind[(int)CardKinds.Ritual] = checkBoxKindRitual.Checked;
           // cardFilterParams.Kind[(int)CardKinds.RitualEffect] = checkBoxKindRitualEffect.Checked;
            cardFilterParams.Kind[(int)CardKinds.Toon] = checkBoxKindToon.Checked;
            cardFilterParams.Kind[(int)CardKinds.Spirit] = checkBoxKindSpirit.Checked;
            cardFilterParams.Kind[(int)CardKinds.Union] = checkBoxKindUnion.Checked;
            cardFilterParams.Kind[(int)CardKinds.Token] = checkBoxKindToken.Checked;
            cardFilterParams.Kind[(int)CardKinds.Spell] = checkBoxKindSpell.Checked;
            cardFilterParams.Kind[(int)CardKinds.Trap] = checkBoxKindTrap.Checked;

            // page 3 - types
            cardFilterParams.Type[(int)CardTypes.None] = checkBoxTypeNone.Checked;
            cardFilterParams.Type[(int)CardTypes.Dragon] = checkBoxTypeDragon.Checked;
            cardFilterParams.Type[(int)CardTypes.Zombie] = checkBoxTypeZombie.Checked;
            cardFilterParams.Type[(int)CardTypes.Fiend] = checkBoxTypeFiend.Checked;
            cardFilterParams.Type[(int)CardTypes.Pyro] = checkBoxTypePyro.Checked;
            cardFilterParams.Type[(int)CardTypes.SeaSerpent] = checkBoxTypeSeaSerp.Checked;
            cardFilterParams.Type[(int)CardTypes.Rock] = checkBoxTypeRock.Checked;
            cardFilterParams.Type[(int)CardTypes.Machine] = checkBoxTypeMachine.Checked;
            cardFilterParams.Type[(int)CardTypes.Fish] = checkBoxTypeFish.Checked;
            cardFilterParams.Type[(int)CardTypes.Dinosaur] = checkBoxTypeDino.Checked;
            cardFilterParams.Type[(int)CardTypes.Insect] = checkBoxTypeInsect.Checked;
            cardFilterParams.Type[(int)CardTypes.Beast] = checkBoxTypeBeast.Checked;
            cardFilterParams.Type[(int)CardTypes.BeastWarrior] = checkBoxTypeBsWarrior.Checked;
            cardFilterParams.Type[(int)CardTypes.Plant] = checkBoxTypePlant.Checked;
            cardFilterParams.Type[(int)CardTypes.Aqua] = checkBoxTypeAqua.Checked;
            cardFilterParams.Type[(int)CardTypes.Warrior] = checkBoxTypeWarrior.Checked;
            cardFilterParams.Type[(int)CardTypes.WingedBeast] = checkBoxTypeWBeast.Checked;
            cardFilterParams.Type[(int)CardTypes.Fairy] = checkBoxTypeFairy.Checked;
            cardFilterParams.Type[(int)CardTypes.Spellcaster] = checkBoxTypeSpellcaster.Checked;
            cardFilterParams.Type[(int)CardTypes.Thunder] = checkBoxTypeThunder.Checked;
            cardFilterParams.Type[(int)CardTypes.Reptile] = checkBoxTypeReptile.Checked;
            cardFilterParams.Type[(int)CardTypes.DivineBeast] = checkBoxTypeDBeast.Checked;
            cardFilterParams.Type[(int)CardTypes.Spell] = checkBoxTypeSpell.Checked;
            cardFilterParams.Type[(int)CardTypes.Trap] = checkBoxTypeTrap.Checked;

            // page 4 - attributes
            cardFilterParams.Attr[(int)CardAttributes.None] = checkBoxAttrNone.Checked;
            cardFilterParams.Attr[(int)CardAttributes.LIGHT] = checkBoxAttrLight.Checked;
            cardFilterParams.Attr[(int)CardAttributes.DARK] = checkBoxAttrDark.Checked;
            cardFilterParams.Attr[(int)CardAttributes.WATER] = checkBoxAttrWater.Checked;
            cardFilterParams.Attr[(int)CardAttributes.FIRE] = checkBoxAttrFire.Checked;
            cardFilterParams.Attr[(int)CardAttributes.EARTH] = checkBoxAttrEarth.Checked;
            cardFilterParams.Attr[(int)CardAttributes.WIND] = checkBoxAttrWind.Checked;
            cardFilterParams.Attr[(int)CardAttributes.DIVINE] = checkBoxAttrDivine.Checked;
            cardFilterParams.Attr[(int)CardAttributes.SPELL] = checkBoxAttrSpell.Checked;
            cardFilterParams.Attr[(int)CardAttributes.TRAP] = checkBoxAttrTrap.Checked;

            // page 5 - S/T icons
            cardFilterParams.Icon[(int)CardIcons.None] = checkBoxIconNone.Checked;
            cardFilterParams.Icon[(int)CardIcons.Counter] = checkBoxIconCounter.Checked;
            cardFilterParams.Icon[(int)CardIcons.Field] = checkBoxIconField.Checked;
            cardFilterParams.Icon[(int)CardIcons.Equip] = checkBoxIconEquip.Checked;
            cardFilterParams.Icon[(int)CardIcons.Continuous] = checkBoxIconContinuous.Checked;
            cardFilterParams.Icon[(int)CardIcons.QuickPlay] = checkBoxIconQuickPlay.Checked;
            cardFilterParams.Icon[(int)CardIcons.RitualSpell] = checkBoxIconRitual.Checked;

            // page 6 - rarity & misc
            cardFilterParams.Rarity[(int)CardRarity.Common] = checkBoxRarityCommon.Checked;
            cardFilterParams.Rarity[(int)CardRarity.Rare] = checkBoxRarityRare.Checked;
            cardFilterParams.Rarity[(int)CardRarity.SuperRare] = checkBoxRaritySuperRare.Checked;
            cardFilterParams.Rarity[(int)CardRarity.UltraRare] = checkBoxRarityUltraRare.Checked;
            cardFilterParams.Rarity[(int)CardRarity.UltimateRare] = checkBoxRarityUltimateRare.Checked;

            cardFilterParams.CardExists = checkBoxMiscCardExists.Checked;

        }

        void LoadFilters()
        {
            // page 1 - typables
            textBoxName.Text = cardFilterParams.Name;
            if (cardFilterParams.MinCardID > 0)
                fastTextBoxIDmin.Text = cardFilterParams.MinCardID.ToString();
            if (cardFilterParams.MaxCardID > 0)
                fastTextBoxIDmax.Text = cardFilterParams.MaxCardID.ToString();
            if (cardFilterParams.MinATK > 0)
                fastTextBoxATKmin.Text = cardFilterParams.MinATK.ToString();
            if (cardFilterParams.MaxATK > 0)
                fastTextBoxATKmax.Text = cardFilterParams.MaxATK.ToString();
            if (cardFilterParams.MinDEF > 0)
                fastTextBoxDEFmin.Text = cardFilterParams.MinDEF.ToString();
            if (cardFilterParams.MaxDEF > 0)
                fastTextBoxDEFmax.Text = cardFilterParams.MaxDEF.ToString();
            if (cardFilterParams.MinPassword > 0)
                fastTextBoxPassMin.Text = cardFilterParams.MinPassword.ToString();
            if (cardFilterParams.MaxPassword > 0)
                fastTextBoxPassMax.Text = cardFilterParams.MaxPassword.ToString();
            if (cardFilterParams.MinLevel > 0)
                fastTextBoxLVmin.Text = cardFilterParams.MinLevel.ToString();
            if (cardFilterParams.MaxLevel > 0)
                fastTextBoxLVmax.Text = cardFilterParams.MaxLevel.ToString();

            checkBoxCase.Checked = cardFilterParams.MatchCase;
            checkBoxMatch.Checked = cardFilterParams.MatchExact;


            // page 2  - kinds
            checkBoxKindNormal.Checked = cardFilterParams.Kind[(int)CardKinds.Normal];
            checkBoxKindEffect.Checked = cardFilterParams.Kind[(int)CardKinds.Effect];
            checkBoxKindFusion.Checked = cardFilterParams.Kind[(int)CardKinds.Fusion];
            checkBoxKindRitual.Checked = cardFilterParams.Kind[(int)CardKinds.Ritual];
            checkBoxKindToon.Checked =  cardFilterParams.Kind[(int)CardKinds.Toon];
            checkBoxKindSpirit.Checked = cardFilterParams.Kind[(int)CardKinds.Spirit];
            checkBoxKindUnion.Checked = cardFilterParams.Kind[(int)CardKinds.Union];
            checkBoxKindToken.Checked = cardFilterParams.Kind[(int)CardKinds.Token];
            checkBoxKindSpell.Checked = cardFilterParams.Kind[(int)CardKinds.Spell];
            checkBoxKindTrap.Checked = cardFilterParams.Kind[(int)CardKinds.Trap];

            // page 3 - types
            checkBoxTypeNone.Checked = cardFilterParams.Type[(int)CardTypes.None];
            checkBoxTypeDragon.Checked = cardFilterParams.Type[(int)CardTypes.Dragon];
            checkBoxTypeZombie.Checked = cardFilterParams.Type[(int)CardTypes.Zombie];
            checkBoxTypeFiend.Checked = cardFilterParams.Type[(int)CardTypes.Fiend];
            checkBoxTypePyro.Checked = cardFilterParams.Type[(int)CardTypes.Pyro];
            checkBoxTypeSeaSerp.Checked = cardFilterParams.Type[(int)CardTypes.SeaSerpent];
            checkBoxTypeRock.Checked = cardFilterParams.Type[(int)CardTypes.Rock];
            checkBoxTypeMachine.Checked = cardFilterParams.Type[(int)CardTypes.Machine];
            checkBoxTypeFish.Checked = cardFilterParams.Type[(int)CardTypes.Fish];
            checkBoxTypeDino.Checked = cardFilterParams.Type[(int)CardTypes.Dinosaur];
            checkBoxTypeInsect.Checked = cardFilterParams.Type[(int)CardTypes.Insect];
            checkBoxTypeBeast.Checked = cardFilterParams.Type[(int)CardTypes.Beast];
            checkBoxTypeBsWarrior.Checked = cardFilterParams.Type[(int)CardTypes.BeastWarrior];
            checkBoxTypePlant.Checked = cardFilterParams.Type[(int)CardTypes.Plant];
            checkBoxTypeAqua.Checked = cardFilterParams.Type[(int)CardTypes.Aqua];
            checkBoxTypeWarrior.Checked = cardFilterParams.Type[(int)CardTypes.Warrior];
            checkBoxTypeWBeast.Checked = cardFilterParams.Type[(int)CardTypes.WingedBeast];
            checkBoxTypeFairy.Checked = cardFilterParams.Type[(int)CardTypes.Fairy];
            checkBoxTypeSpellcaster.Checked = cardFilterParams.Type[(int)CardTypes.Spellcaster];
            checkBoxTypeThunder.Checked = cardFilterParams.Type[(int)CardTypes.Thunder];
            checkBoxTypeReptile.Checked = cardFilterParams.Type[(int)CardTypes.Reptile];
            checkBoxTypeDBeast.Checked = cardFilterParams.Type[(int)CardTypes.DivineBeast];
            checkBoxTypeSpell.Checked = cardFilterParams.Type[(int)CardTypes.Spell];
            checkBoxTypeTrap.Checked = cardFilterParams.Type[(int)CardTypes.Trap];

            // page 4 - attributes
            checkBoxAttrNone.Checked = cardFilterParams.Attr[(int)CardAttributes.None];
            checkBoxAttrLight.Checked = cardFilterParams.Attr[(int)CardAttributes.LIGHT];
            checkBoxAttrDark.Checked = cardFilterParams.Attr[(int)CardAttributes.DARK];
            checkBoxAttrWater.Checked = cardFilterParams.Attr[(int)CardAttributes.WATER];
            checkBoxAttrFire.Checked = cardFilterParams.Attr[(int)CardAttributes.FIRE];
            checkBoxAttrEarth.Checked = cardFilterParams.Attr[(int)CardAttributes.EARTH];
            checkBoxAttrWind.Checked = cardFilterParams.Attr[(int)CardAttributes.WIND];
            checkBoxAttrDivine.Checked = cardFilterParams.Attr[(int)CardAttributes.DIVINE];
            checkBoxAttrSpell.Checked = cardFilterParams.Attr[(int)CardAttributes.SPELL];
            checkBoxAttrTrap.Checked = cardFilterParams.Attr[(int)CardAttributes.TRAP];

            // page 5 - S/T icons
            checkBoxIconNone.Checked = cardFilterParams.Icon[(int)CardIcons.None];
            checkBoxIconCounter.Checked = cardFilterParams.Icon[(int)CardIcons.Counter];
            checkBoxIconField.Checked = cardFilterParams.Icon[(int)CardIcons.Field];
            checkBoxIconEquip.Checked = cardFilterParams.Icon[(int)CardIcons.Equip];
            checkBoxIconContinuous.Checked = cardFilterParams.Icon[(int)CardIcons.Continuous];
            checkBoxIconQuickPlay.Checked = cardFilterParams.Icon[(int)CardIcons.QuickPlay];
            checkBoxIconRitual.Checked = cardFilterParams.Icon[(int)CardIcons.RitualSpell];

            // page 6 - rarity & misc
            checkBoxRarityCommon.Checked = cardFilterParams.Rarity[(int)CardRarity.Common];
            checkBoxRarityRare.Checked = cardFilterParams.Rarity[(int)CardRarity.Rare];
            checkBoxRaritySuperRare.Checked = cardFilterParams.Rarity[(int)CardRarity.SuperRare];
            checkBoxRarityUltraRare.Checked = cardFilterParams.Rarity[(int)CardRarity.UltraRare];
            checkBoxRarityUltraRare.Checked = cardFilterParams.Rarity[(int)CardRarity.UltimateRare];

            checkBoxMiscCardExists.Checked = cardFilterParams.CardExists;

        }

        public void ResetPage(int pageIndex)
        {
            switch (pageIndex)
            {
                case 0:
                    textBoxName.Text = "";
                    fastTextBoxIDmin.Text = "";
                    fastTextBoxIDmax.Text = "";
                    fastTextBoxATKmin.Text = "";
                    fastTextBoxATKmax.Text = "";
                    fastTextBoxDEFmin.Text = "";
                    fastTextBoxDEFmax.Text = "";
                    fastTextBoxPassMin.Text = "";
                    fastTextBoxPassMax.Text = "";
                    fastTextBoxLVmin.Text = "";
                    fastTextBoxLVmax.Text = "";
                    break;
                case 1:
                    checkBoxKindNormal.Checked = false;
                    checkBoxKindEffect.Checked = false;
                    checkBoxKindFusion.Checked = false;
                    checkBoxKindRitual.Checked = false;
                    checkBoxKindToon.Checked = false;
                    checkBoxKindSpirit.Checked = false;
                    checkBoxKindUnion.Checked = false;
                    checkBoxKindToken.Checked = false;
                    checkBoxKindSpell.Checked = false;
                    checkBoxKindTrap.Checked = false;
                    break;
                case 2:
                    checkBoxTypeNone.Checked = false;
                    checkBoxTypeDragon.Checked = false;
                    checkBoxTypeZombie.Checked = false;
                    checkBoxTypeFiend.Checked = false;
                    checkBoxTypePyro.Checked = false;
                    checkBoxTypeSeaSerp.Checked = false;
                    checkBoxTypeRock.Checked = false;
                    checkBoxTypeMachine.Checked = false;
                    checkBoxTypeFish.Checked = false;
                    checkBoxTypeDino.Checked = false;
                    checkBoxTypeInsect.Checked = false;
                    checkBoxTypeBeast.Checked = false;
                    checkBoxTypeBsWarrior.Checked = false;
                    checkBoxTypePlant.Checked = false;
                    checkBoxTypeAqua.Checked = false;
                    checkBoxTypeWarrior.Checked = false;
                    checkBoxTypeWBeast.Checked = false;
                    checkBoxTypeFairy.Checked = false;
                    checkBoxTypeSpellcaster.Checked = false;
                    checkBoxTypeThunder.Checked = false;
                    checkBoxTypeReptile.Checked = false;
                    checkBoxTypeDBeast.Checked = false;
                    checkBoxTypeSpell.Checked = false;
                    checkBoxTypeTrap.Checked = false;
                    break;
                case 3:
                    checkBoxAttrNone.Checked = false;
                    checkBoxAttrLight.Checked = false;
                    checkBoxAttrDark.Checked = false;
                    checkBoxAttrWater.Checked = false;
                    checkBoxAttrFire.Checked = false;
                    checkBoxAttrEarth.Checked = false;
                    checkBoxAttrWind.Checked = false;
                    checkBoxAttrDivine.Checked = false;
                    checkBoxAttrSpell.Checked = false;
                    checkBoxAttrTrap.Checked = false;
                    break;
                case 4:
                    checkBoxIconNone.Checked = false;
                    checkBoxIconCounter.Checked = false;
                    checkBoxIconField.Checked = false;
                    checkBoxIconEquip.Checked = false;
                    checkBoxIconContinuous.Checked = false;
                    checkBoxIconQuickPlay.Checked = false;
                    checkBoxIconRitual.Checked = false;
                    break;
                case 5:
                    checkBoxRarityCommon.Checked = false;
                    checkBoxRarityRare.Checked = false;
                    checkBoxRaritySuperRare.Checked = false;
                    checkBoxRarityUltraRare.Checked = false;
                    checkBoxRarityUltraRare.Checked = false;

                    checkBoxMiscCardExists.Checked = true;
                    break;
                default:
                    break;
            }
            SaveFilters();
        }

        public void ResetAllPages()
        {
            for (int i = 0; i < tabControl1.TabCount; i++)
                ResetPage(i);
        }

        public bool bAreAnyFiltersEnabled()
        {
            if (!string.IsNullOrEmpty(textBoxName.Text)
            || !string.IsNullOrEmpty(fastTextBoxIDmin.Text)
            || !string.IsNullOrEmpty(fastTextBoxIDmax.Text)
            || !string.IsNullOrEmpty(fastTextBoxATKmin.Text)
            || !string.IsNullOrEmpty(fastTextBoxATKmax.Text)
            || !string.IsNullOrEmpty(fastTextBoxDEFmin.Text)
            || !string.IsNullOrEmpty(fastTextBoxDEFmax.Text)
            || !string.IsNullOrEmpty(fastTextBoxPassMin.Text)
            || !string.IsNullOrEmpty(fastTextBoxPassMax.Text)
            || !string.IsNullOrEmpty(fastTextBoxLVmin.Text)
            || !string.IsNullOrEmpty(fastTextBoxLVmax.Text))
            {
                return true;
            }

            if (checkBoxKindNormal.Checked
            || checkBoxKindEffect.Checked
            || checkBoxKindFusion.Checked
            || checkBoxKindRitual.Checked
            || checkBoxKindToon.Checked
            || checkBoxKindSpirit.Checked
            || checkBoxKindUnion.Checked
            || checkBoxKindToken.Checked
            || checkBoxKindSpell.Checked
            || checkBoxKindTrap.Checked
            || checkBoxTypeNone.Checked
            || checkBoxTypeDragon.Checked
            || checkBoxTypeZombie.Checked
            || checkBoxTypeFiend.Checked
            || checkBoxTypePyro.Checked
            || checkBoxTypeSeaSerp.Checked
            || checkBoxTypeRock.Checked
            || checkBoxTypeMachine.Checked
            || checkBoxTypeFish.Checked
            || checkBoxTypeDino.Checked
            || checkBoxTypeInsect.Checked
            || checkBoxTypeBeast.Checked
            || checkBoxTypeBsWarrior.Checked
            || checkBoxTypePlant.Checked
            || checkBoxTypeAqua.Checked
            || checkBoxTypeWarrior.Checked
            || checkBoxTypeWBeast.Checked
            || checkBoxTypeFairy.Checked
            || checkBoxTypeSpellcaster.Checked
            || checkBoxTypeThunder.Checked
            || checkBoxTypeReptile.Checked
            || checkBoxTypeDBeast.Checked
            || checkBoxTypeSpell.Checked
            || checkBoxTypeTrap.Checked
            || checkBoxAttrNone.Checked
            || checkBoxAttrLight.Checked
            || checkBoxAttrDark.Checked
            || checkBoxAttrWater.Checked
            || checkBoxAttrFire.Checked
            || checkBoxAttrEarth.Checked
            || checkBoxAttrWind.Checked
            || checkBoxAttrDivine.Checked
            || checkBoxAttrSpell.Checked
            || checkBoxAttrTrap.Checked
            || checkBoxIconNone.Checked
            || checkBoxIconCounter.Checked
            || checkBoxIconField.Checked
            || checkBoxIconEquip.Checked
            || checkBoxIconContinuous.Checked
            || checkBoxIconQuickPlay.Checked
            || checkBoxIconRitual.Checked
            || checkBoxRarityCommon.Checked
            || checkBoxRarityRare.Checked
            || checkBoxRaritySuperRare.Checked
            || checkBoxRarityUltraRare.Checked
            || checkBoxRarityUltraRare.Checked
            || checkBoxMiscCardExists.Checked)
            {
                return true;
            }
            return false;
        }

        private bool Int32TextAcceptor(string oldText, string newText, string input, int offset, int length)
        {
            int value = 0;
            return Int32.TryParse(newText, out value); ;
        }

        void SetAcceptors()
        {
            fastTextBoxIDmin.TextAcceptor = Int32TextAcceptor;
            fastTextBoxIDmax.TextAcceptor = Int32TextAcceptor;
            fastTextBoxATKmin.TextAcceptor = Int32TextAcceptor;
            fastTextBoxATKmax.TextAcceptor = Int32TextAcceptor;
            fastTextBoxDEFmin.TextAcceptor = Int32TextAcceptor;
            fastTextBoxDEFmax.TextAcceptor = Int32TextAcceptor;
            fastTextBoxPassMin.TextAcceptor = Int32TextAcceptor;
            fastTextBoxPassMax.TextAcceptor = Int32TextAcceptor;
            fastTextBoxLVmin.TextAcceptor = Int32TextAcceptor;
            fastTextBoxLVmax.TextAcceptor = Int32TextAcceptor;
        }

        private void FilterBox_Load(object sender, EventArgs e)
        {
            // start pos at the corner of the parent window
            Location = new Point(Owner.Location.X + 40, Owner.Location.Y + 40);
            SetAcceptors();
            LoadFilters();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            SaveFilters();
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void buttonFilter_Click(object sender, EventArgs e)
        {
            SaveFilters();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonResetPage_Click(object sender, EventArgs e)
        {
            ResetPage(tabControl1.SelectedIndex);
        }

        private void buttonResetAll_Click(object sender, EventArgs e)
        {
            ResetAllPages();
        }

        private void FilterBox_Activated(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            textBoxName.Focus();
        }
    }
}
