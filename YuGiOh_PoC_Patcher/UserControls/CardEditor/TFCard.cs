using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;

namespace YuGiOh_PoC_Patcher.UserControls
{
    // stolen from: https://www.codeproject.com/Articles/22717/Using-PropertyGrid
    public class CardTypesConverter : EnumConverter
    {
        private Type _enumType;
        /// <summary />Initializing instance</summary />
        /// <param name=""type"" />type Enum</param />
        /// this is only one function, that you must
        /// change. All another functions for enums
        /// you can use by Ctrl+C/Ctrl+V
        public CardTypesConverter(Type type)
            : base(type)
        {
            _enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context,
            Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture,
            object value, Type destType)
        {
            if (Enum.GetName(_enumType, value) == null)
            {
                return "Unknown";
            }
            FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
            DescriptionAttribute dna =
                (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context,
            Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture,
            object value)
        {
            foreach (FieldInfo fi in _enumType.GetFields())
            {
                DescriptionAttribute dna =
                (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }
            return Enum.Parse(_enumType, (string)value);
        }
    }

    [TypeConverter(typeof(CardTypesConverter))]
    public enum CardTypes
    {
        [Description("None")]
        None,
        [Description("Dragon")]
        Dragon,
        [Description("Zombie")]
        Zombie,
        [Description("Fiend")]
        Fiend,
        [Description("Pyro")]
        Pyro,
        [Description("Sea Serpent")]
        SeaSerpent,
        [Description("Rock")]
        Rock,
        [Description("Machine")]
        Machine,
        [Description("Fish")]
        Fish,
        [Description("Dinosaur")]
        Dinosaur,
        [Description("Insect")]
        Insect,
        [Description("Beast")]
        Beast,
        [Description("Beast-Warrior")]
        BeastWarrior,
        [Description("Plant")]
        Plant,
        [Description("Aqua")]
        Aqua,
        [Description("Warrior")]
        Warrior,
        [Description("Winged Beast")]
        WingedBeast,
        [Description("Fairy")]
        Fairy,
        [Description("Spellcaster")]
        Spellcaster,
        [Description("Thunder")]
        Thunder,
        [Description("Reptile")]
        Reptile,
        [Description("Divine-Beast")]
        DivineBeast,
        [Description("Spell")]
        Spell,
        [Description("Trap")]
        Trap
    };

    [TypeConverter(typeof(CardTypesConverter))]
    public enum CardKinds
    {
        [Description("Normal")]
        Normal,
        [Description("Effect")]
        Effect,
        [Description("Fusion")]
        Fusion,
        [Description("Fusion/Effect")]
        FusionEffect,
        [Description("Ritual")]
        Ritual,
        [Description("Ritual/Effect")]
        RitualEffect,
        [Description("Toon/Effect")]
        Toon,
        [Description("Spirit/Effect")]
        Spirit,
        [Description("Union/Effect")]
        Union,
        [Description("Token")]
        Token,
        [Description("(todo - unk1)")]
        unk1,
        [Description("(todo - unk2)")]
        unk2,
        [Description("(todo - unk3)")]
        unk3,
        [Description("Spell")]
        Spell = 13,
        [Description("Trap")]
        Trap = 14
    };

    [TypeConverter(typeof(CardTypesConverter))]
    public enum CardRarity
    {
        [Description("Common")]
        Common,
        [Description("Rare")]
        Rare,
        [Description("Super Rare")]
        SuperRare,
        [Description("Ultra Rare")]
        UltraRare,
        [Description("Ultimate Rare")]
        UltimateRare
    };

    [TypeConverter(typeof(CardTypesConverter))]
    public enum CardAttributes
    {
        [Description("None")]
        None,
        [Description("LIGHT")]
        LIGHT,
        [Description("DARK")]
        DARK,
        [Description("WATER")]
        WATER,
        [Description("FIRE")]
        FIRE,
        [Description("EARTH")]
        EARTH,
        [Description("WIND")]
        WIND,
        [Description("DIVINE")]
        DIVINE,
        [Description("SPELL")]
        SPELL,
        [Description("TRAP")]
        TRAP
    };

    [TypeConverter(typeof(CardTypesConverter))]
    public enum CardIcons
    {
        [Description("None")]
        None,
        [Description("Counter")]
        Counter,
        [Description("Field")]
        Field,
        [Description("Equip")]
        Equip,
        [Description("Continuous")]
        Continuous,
        [Description("Quick-Play")]
        QuickPlay,
        [Description("Ritual")]
        RitualSpell
    };

    [TypeConverter(typeof(CardTypesConverter))]
    public enum CardProps
    {
        [Description("Card ID")]
        CardID,
        [Description("Name")]
        Name,
        [Description("Kind")]
        Kind,
        [Description("Level")]
        Level,
        [Description("ATK")]
        ATK,
        [Description("DEF")]
        DEF,
        [Description("Type")]
        Type,
        [Description("Attribute")]
        Attr,
        [Description("Icon")]
        Icon,
        [Description("Rarity")]
        Rarity,
        [Description("Password")]
        Password,
        [Description("CardExists")]
        CardExists,
        [Description("Description")]
        Description
    }

    public class TFCard
    {
        int p_CardID;

        [Category("Uneditable")]
        [ReadOnly(true)]
        [DisplayName("Card ID")]
        [Description("Internal Konami Card ID")]
        public int CardID
        {
            get { return p_CardID; }
            set { p_CardID = value; }
        }

        string p_Name;

        [Category("Basic")]
        [DisplayName("Name")]
        [Description("Card name\nFor Japanese, the \"$R\" marker is used to mark Katakana text.\nHiragana subtext group is in parentheses.")]
        public string Name
        {
            get { return p_Name; }
            set { p_Name = value; }
        }

        string p_Description;
        [Category("Basic")]
        [DisplayName("Description")]
        [Description("Card description\nFor Japanese, the \"$R\" marker is used to mark Katakana text.\nHiragana subtext group is in parentheses.")]
        public string Description
        {
            get { return p_Description; }
            set { p_Description = value; }
        }

        int p_Password;
        [Category("Misc")]
        [DisplayName("Password")]
        [Description("Card password\nAlways 8 characters long.")]
        public int Password
        {
            get { return p_Password; }
            set { if (value < 0) p_Password = 0; else p_Password = value; }
        }

        int p_ATK;
        [Category("Stats (basic)")]
        [DisplayName("ATK")]
        [Description("Attack points\nMaximum value is 5110 (width: 9 bits, last digit ignored)\nIf this value is 5110, the game will treat this as variable ATK.")]
        public int ATK
        {
            get { return p_ATK; }
            set { if (value > 5110) p_ATK = 5110; else if (value < 0) p_ATK = 0; else p_ATK = value; }
        }

        int p_DEF;
        [Category("Stats (basic)")]
        [DisplayName("DEF")]
        [Description("Defense points\nMaximum value is 5110 (width: 9 bits, last digit ignored)\nIf this value is 5110, the game will treat this as variable DEF.")]
        public int DEF
        {
            get { return p_DEF; }
            set { if (value > 5110) p_DEF = 5110; else if (value < 0) p_DEF = 0; else p_DEF = value; }
        }

        bool p_CardExistFlag;
        [Category("Misc")]
        [DisplayName("Card exists")]
        [Description("Flag whether or not this card exists in real life / is game exclusive")]
        public bool CardExistFlag
        {
            get { return p_CardExistFlag; }
            set { p_CardExistFlag = value; }
        }

        CardKinds p_Kind;
        [Category("Stats (basic)")]
        [DisplayName("Kind")]
        [Description("The kind of card / card frame\nMaximum value is 15 (width: 4 bits)")]
        [TypeConverter(typeof(CardTypesConverter))]
        public CardKinds Kind
        {
            get { return p_Kind; }
            set { p_Kind = value; }
        }

        CardAttributes p_Attr;
        [Category("Stats (secondary)")]
        [DisplayName("Attribute")]
        [Description("Card attribute\nMaximum value is 15 (width: 4 bits)")]
        [TypeConverter(typeof(CardTypesConverter))]
        public CardAttributes Attr
        {
            get { return p_Attr; }
            set { p_Attr = value; }
        }

        int p_Level;
        [Category("Stats (secondary)")]
        [DisplayName("Level")]
        [Description("Card level\nMaximum value is 15 (width: 4 bits)")]
        public int Level
        {
            get { return p_Level; }
            set { if (value < 0) p_Level = 0; else p_Level = value; }
        }

        CardIcons p_Icon;
        [Category("Stats (secondary)")]
        [DisplayName("Spell/Trap icon")]
        [Description("Spell/Trap card icon\nMaximum value is 7 (width: 3 bits)")]
        [TypeConverter(typeof(CardTypesConverter))]
        public CardIcons Icon
        {
            get { return p_Icon; }
            set { p_Icon = value; }
        }

        //int p_Type;
        CardTypes p_Type;
        [Category("Stats (secondary)")]
        [DisplayName("Type")]
        [Description("Card type\nMaximum value is 31 (width: 5 bits)")]
        [TypeConverter(typeof(CardTypesConverter))]
        //public int Type
        public CardTypes Type
        {
            get { return p_Type; }
            set { p_Type = value; }
        }

        CardRarity p_Rarity;
        [Category("Misc")]
        [DisplayName("Rarity")]
        [Description("Card rarity\nMaximum value is 15 (width: 4 bits)")]
        public CardRarity Rarity
        {
            get { return p_Rarity; }
            set { p_Rarity = value; }
        }
    }

    public class CardSearchParams
    {
        string p_SearchString;
        public string SearchString
        {
            get { return p_SearchString; }
            set { p_SearchString = value; }
        }

        int p_SearchComboBoxIndex;
        public int SearchComboBoxIndex
        {
            get { return p_SearchComboBoxIndex; }
            set { p_SearchComboBoxIndex = value; }
        }

        string p_ReplaceString;
        public string ReplaceString
        {
            get { return p_ReplaceString; }
            set { p_ReplaceString = value; }
        }

        int p_ReplaceComboBoxIndex;
        public int ReplaceComboBoxIndex
        {
            get { return p_ReplaceComboBoxIndex; }
            set { p_ReplaceComboBoxIndex = value; }
        }

        bool p_bSearchCardID;
        public bool bSearchCardID
        {
            get { return p_bSearchCardID; }
            set { p_bSearchCardID = value; }
        }

        bool p_bSearchName;
        public bool bSearchName
        {
            get { return p_bSearchName; }
            set { p_bSearchName = value; }
        }

        bool p_bSearchDescription;
        public bool bSearchDescription
        {
            get { return p_bSearchDescription; }
            set { p_bSearchDescription = value; }
        }

        bool p_bSearchKind;
        public bool bSearchKind
        {
            get { return p_bSearchKind; }
            set { p_bSearchKind = value; }
        }

        bool p_bSearchLevel;
        public bool bSearchLevel
        {
            get { return p_bSearchLevel; }
            set { p_bSearchLevel = value; }
        }

        bool p_bSearchATK;
        public bool bSearchATK
        {
            get { return p_bSearchATK; }
            set { p_bSearchATK = value; }
        }

        bool p_bSearchDEF;
        public bool bSearchDEF
        {
            get { return p_bSearchDEF; }
            set { p_bSearchDEF = value; }
        }

        bool p_bSearchType;
        public bool bSearchType
        {
            get { return p_bSearchType; }
            set { p_bSearchType = value; }
        }

        bool p_bSearchAttr;
        public bool bSearchAttr
        {
            get { return p_bSearchAttr; }
            set { p_bSearchAttr = value; }
        }

        bool p_bSearchIcon;
        public bool bSearchIcon
        {
            get { return p_bSearchIcon; }
            set { p_bSearchIcon = value; }
        }

        bool p_bSearchRarity;
        public bool bSearchRarity
        {
            get { return p_bSearchRarity; }
            set { p_bSearchRarity = value; }
        }

        bool p_bSearchPassword;
        public bool bSearchPassword
        {
            get { return p_bSearchPassword; }
            set { p_bSearchPassword = value; }
        }

        bool p_bSearchCardExists;
        public bool bSearchCardExists
        {
            get { return p_bSearchCardExists; }
            set { p_bSearchCardExists = value; }
        }

        bool p_bMatchWhole;
        public bool bMatchWhole
        {
            get { return p_bMatchWhole; }
            set { p_bMatchWhole = value; }
        }

        bool p_bMatchCase;
        public bool bMatchCase
        {
            get { return p_bMatchCase; }
            set { p_bMatchCase = value; }
        }

        int p_SearchResultSubStrIndex_Name = -1;
        public int SearchResultSubStrIndex_Name
        {
            get { return p_SearchResultSubStrIndex_Name; }
            set { p_SearchResultSubStrIndex_Name = value; }
        }

        int p_SearchResultSubStrIndex_Desc = -1;
        public int SearchResultSubStrIndex_Desc
        {
            get { return p_SearchResultSubStrIndex_Desc; }
            set { p_SearchResultSubStrIndex_Desc = value; }
        }

        // output values...

        int p_SearchResultIndex = -1;
        public int SearchResultIndex
        {
            get { return p_SearchResultIndex; }
            set { p_SearchResultIndex = value; }
        }

        int p_SearchResultSubStrIndex = -1;
        public int SearchResultSubStrIndex
        {
            get { return p_SearchResultSubStrIndex; }
            set { p_SearchResultSubStrIndex = value; }
        }

        CardProps p_SearchContext;
        public CardProps SearchContext
        {
            get { return p_SearchContext; }
            set { p_SearchContext = value; }
        }

        string p_ResultString;
        public string ResultString
        {
            get { return p_ResultString; }
            set { p_ResultString = value; }
        }
    }

    public class CardSearch
    {
        public int CurrentlySelectedItem = -1;
        public int CurrentlySelectedSubItem = -1;
        public bool bFirstSearch = true;

        void SearchCaseSensitive(CardSearchParams inParams, ListView listView, bool bNoLoop)
        {
            int si = CurrentlySelectedItem;
            int sj = inParams.SearchResultSubStrIndex_Name + 1;
            int sk;
            int sl = inParams.SearchResultSubStrIndex_Desc + 1;

            for (int i = 0; i < listView.Items.Count; i++)
            {
                if (bNoLoop)
                    i = si;
                else
                    si %= listView.Items.Count;

                if (inParams.bSearchCardID && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.CardID)) || bFirstSearch)) // the second part of condition ensures we move onwards
                {
                    if (listView.Items[si].SubItems[(int)CardProps.CardID].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.CardID].Text;
                        CurrentlySelectedSubItem = (int)CardProps.CardID;
                        inParams.SearchContext = CardProps.CardID;
                        return;
                    }
                }

                if (inParams.bSearchName)
                {
                    sk = listView.Items[si].SubItems[(int)CardProps.Name].Text.Substring(sj).IndexOf(inParams.SearchString);

                    if (sk != -1)
                    {
                        if (inParams.SearchResultSubStrIndex_Name != -1 && (CurrentlySelectedItem == si))
                            sk += inParams.SearchResultSubStrIndex_Name + 1;
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex_Name = sk;
                        inParams.SearchResultSubStrIndex = sk;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Name].Text.Substring(sk, inParams.SearchString.Length);
                        CurrentlySelectedSubItem = (int)CardProps.Name;
                        inParams.SearchContext = CardProps.Name;
                        return;
                    }
                }

                if (inParams.bSearchDescription)
                {
                    sk = listView.Items[si].SubItems[(int)CardProps.Description].Text.Substring(sl).IndexOf(inParams.SearchString);

                    if (sk != -1)
                    {
                        if (inParams.SearchResultSubStrIndex_Desc != -1 && (CurrentlySelectedItem == si))
                            sk += inParams.SearchResultSubStrIndex_Desc + 1;
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex_Desc = sk;
                        inParams.SearchResultSubStrIndex = sk;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Description].Text.Substring(sk, inParams.SearchString.Length);
                        CurrentlySelectedSubItem = (int)CardProps.Description;
                        inParams.SearchContext = CardProps.Description;
                        return;
                    }
                }

                if (inParams.bSearchKind && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Kind)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Kind].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Kind].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Kind;
                        inParams.SearchContext = CardProps.Kind;
                        return;
                    }
                }

                if (inParams.bSearchLevel && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Level)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Level].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Level].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Level;
                        inParams.SearchContext = CardProps.Level;
                        return;
                    }
                }

                if (inParams.bSearchATK && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.ATK)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.ATK].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.ATK].Text;
                        CurrentlySelectedSubItem = (int)CardProps.ATK;
                        inParams.SearchContext = CardProps.ATK;
                        return;
                    }
                }

                if (inParams.bSearchDEF && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.DEF)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.DEF].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.DEF].Text;
                        CurrentlySelectedSubItem = (int)CardProps.DEF;
                        inParams.SearchContext = CardProps.DEF;
                        return;
                    }
                }

                if (inParams.bSearchType && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Type)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Type].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Type].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Type;
                        inParams.SearchContext = CardProps.Type;
                        return;
                    }
                }

                if (inParams.bSearchAttr && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Attr)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Attr].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Attr].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Attr;
                        inParams.SearchContext = CardProps.Attr;
                        return;
                    }
                }

                if (inParams.bSearchIcon && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Icon)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Icon].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Icon].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Icon;
                        inParams.SearchContext = CardProps.Icon;
                        return;
                    }
                }

                if (inParams.bSearchRarity && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Rarity)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Rarity].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Rarity].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Rarity;
                        inParams.SearchContext = CardProps.Rarity;
                        return;
                    }
                }

                if (inParams.bSearchPassword && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Password)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Password].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Password].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Password;
                        inParams.SearchContext = CardProps.Password;
                        return;
                    }
                }

                if (inParams.bSearchCardExists && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.CardExists)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.CardExists].Text.Contains(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.CardExists].Text;
                        CurrentlySelectedSubItem = (int)CardProps.CardExists;
                        inParams.SearchContext = CardProps.CardExists;
                        return;
                    }
                }
                inParams.SearchResultSubStrIndex_Name = -1;
                inParams.SearchResultSubStrIndex_Desc = -1;
                sj = 0;
                sl = 0;
                si++;
            }
        }

        void SearchExactCaseSensitive(CardSearchParams inParams, ListView listView, bool bNoLoop)
        {
            int si = CurrentlySelectedItem;

            for (int i = 0; i < listView.Items.Count; i++)
            {
                if (bNoLoop)
                    i = si;
                else
                    si %= listView.Items.Count;

                if (inParams.bSearchCardID && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.CardID)) || bFirstSearch)) // the second part of condition ensures we move onwards
                {
                    if (listView.Items[si].SubItems[(int)CardProps.CardID].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.CardID].Text;
                        CurrentlySelectedSubItem = (int)CardProps.CardID;
                        inParams.SearchContext = CardProps.CardID;
                        return;
                    }
                }

                if (inParams.bSearchName && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Name)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Name].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.SearchResultSubStrIndex_Name = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Name].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Name;
                        inParams.SearchContext = CardProps.Name;
                        return;
                    }
                }

                if (inParams.bSearchDescription && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Description)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Description].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.SearchResultSubStrIndex_Desc = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Description].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Description;
                        inParams.SearchContext = CardProps.Description;
                        return;
                    }
                }

                if (inParams.bSearchKind && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Kind)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Kind].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Kind].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Kind;
                        inParams.SearchContext = CardProps.Kind;
                        return;
                    }
                }

                if (inParams.bSearchLevel && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Level)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Level].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Level].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Level;
                        inParams.SearchContext = CardProps.Level;
                        return;
                    }
                }

                if (inParams.bSearchATK && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.ATK)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.ATK].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.ATK].Text;
                        CurrentlySelectedSubItem = (int)CardProps.ATK;
                        inParams.SearchContext = CardProps.ATK;
                        return;
                    }
                }

                if (inParams.bSearchDEF && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.DEF)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.DEF].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.DEF].Text;
                        CurrentlySelectedSubItem = (int)CardProps.DEF;
                        inParams.SearchContext = CardProps.DEF;
                        return;
                    }
                }

                if (inParams.bSearchType && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Type)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Type].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Type].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Type;
                        inParams.SearchContext = CardProps.Type;
                        return;
                    }
                }

                if (inParams.bSearchAttr && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Attr)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Attr].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Attr].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Attr;
                        inParams.SearchContext = CardProps.Attr;
                        return;
                    }
                }

                if (inParams.bSearchIcon && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Icon)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Icon].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Icon].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Icon;
                        inParams.SearchContext = CardProps.Icon;
                        return;
                    }
                }

                if (inParams.bSearchRarity && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Rarity)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Rarity].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Rarity].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Rarity;
                        inParams.SearchContext = CardProps.Rarity;
                        return;
                    }
                }

                if (inParams.bSearchPassword && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Password)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Password].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Password].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Password;
                        inParams.SearchContext = CardProps.Password;
                        return;
                    }
                }

                if (inParams.bSearchCardExists && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.CardExists)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.CardExists].Text.Equals(inParams.SearchString))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.CardExists].Text;
                        CurrentlySelectedSubItem = (int)CardProps.CardExists;
                        inParams.SearchContext = CardProps.CardExists;
                        return;
                    }
                }
                si++;
            }
        }

        void SearchCaseless(CardSearchParams inParams, ListView listView, bool bNoLoop)
        {
            int si = CurrentlySelectedItem;
            int sj = inParams.SearchResultSubStrIndex_Name + 1;
            int sk;
            int sl = inParams.SearchResultSubStrIndex_Desc + 1;

            for (int i = 0; i < listView.Items.Count; i++)
            {
                if (bNoLoop)
                    i = si;
                else
                    si %= listView.Items.Count;

                if (inParams.bSearchCardID && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.CardID)) || bFirstSearch)) // the second part of condition ensures we move onwards
                {
                    if (listView.Items[si].SubItems[(int)CardProps.CardID].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.CardID].Text;
                        CurrentlySelectedSubItem = (int)CardProps.CardID;
                        inParams.SearchContext = CardProps.CardID;
                        return;
                    }
                }

                if (inParams.bSearchName)
                {
                    sk = listView.Items[si].SubItems[(int)CardProps.Name].Text.Substring(sj).ToUpper().IndexOf(inParams.SearchString.ToUpper());

                    if (sk != -1)
                    {
                        if (inParams.SearchResultSubStrIndex_Name != -1 && (CurrentlySelectedItem == si))
                            sk += inParams.SearchResultSubStrIndex_Name + 1;
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex_Name = sk;
                        inParams.SearchResultSubStrIndex = sk;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Name].Text.Substring(sk, inParams.SearchString.Length);
                        CurrentlySelectedSubItem = (int)CardProps.Name;
                        inParams.SearchContext = CardProps.Name;
                        return;
                    }
                }

                if (inParams.bSearchDescription)
                {
                    sk = listView.Items[si].SubItems[(int)CardProps.Description].Text.Substring(sl).ToUpper().IndexOf(inParams.SearchString.ToUpper());

                    if (sk != -1)
                    {
                        if (inParams.SearchResultSubStrIndex_Desc != -1 && (CurrentlySelectedItem == si))
                            sk += inParams.SearchResultSubStrIndex_Desc + 1;
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex_Desc = sk;
                        inParams.SearchResultSubStrIndex = sk;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Description].Text.Substring(sk, inParams.SearchString.Length);
                        CurrentlySelectedSubItem = (int)CardProps.Description;
                        inParams.SearchContext = CardProps.Description;
                        return;
                    }
                }

                if (inParams.bSearchKind && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Kind)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Kind].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Kind].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Kind;
                        inParams.SearchContext = CardProps.Kind;
                        return;
                    }
                }

                if (inParams.bSearchLevel && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Level)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Level].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Level].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Level;
                        inParams.SearchContext = CardProps.Level;
                        return;
                    }
                }

                if (inParams.bSearchATK && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.ATK)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.ATK].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.ATK].Text;
                        CurrentlySelectedSubItem = (int)CardProps.ATK;
                        inParams.SearchContext = CardProps.ATK;
                        return;
                    }
                }

                if (inParams.bSearchDEF && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.DEF)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.DEF].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.DEF].Text;
                        CurrentlySelectedSubItem = (int)CardProps.DEF;
                        inParams.SearchContext = CardProps.DEF;
                        return;
                    }
                }

                if (inParams.bSearchType && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Type)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Type].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Type].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Type;
                        inParams.SearchContext = CardProps.Type;
                        return;
                    }
                }

                if (inParams.bSearchAttr && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Attr)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Attr].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Attr].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Attr;
                        inParams.SearchContext = CardProps.Attr;
                        return;
                    }
                }

                if (inParams.bSearchIcon && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Icon)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Icon].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Icon].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Icon;
                        inParams.SearchContext = CardProps.Icon;
                        return;
                    }
                }

                if (inParams.bSearchRarity && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Rarity)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Rarity].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Rarity].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Rarity;
                        inParams.SearchContext = CardProps.Rarity;
                        return;
                    }
                }

                if (inParams.bSearchPassword && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Password)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Password].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Password].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Password;
                        inParams.SearchContext = CardProps.Password;
                        return;
                    }
                }

                if (inParams.bSearchCardExists && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.CardExists)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.CardExists].Text.ToUpper().Contains(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.CardExists].Text;
                        CurrentlySelectedSubItem = (int)CardProps.CardExists;
                        inParams.SearchContext = CardProps.CardExists;
                        return;
                    }
                }
                inParams.SearchResultSubStrIndex_Name = -1;
                inParams.SearchResultSubStrIndex_Desc = -1;
                sj = 0;
                sl = 0;
                si++;
            }
        }

        void SearchExactCaseless(CardSearchParams inParams, ListView listView, bool bNoLoop)
        {
            int si = CurrentlySelectedItem;

            for (int i = 0; i < listView.Items.Count; i++)
            {
                if (bNoLoop)
                    i = si;
                else
                    si %= listView.Items.Count;

                if (inParams.bSearchCardID && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.CardID)) || bFirstSearch)) // the second part of condition ensures we move onwards
                {
                    if (listView.Items[si].SubItems[(int)CardProps.CardID].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.CardID].Text;
                        CurrentlySelectedSubItem = (int)CardProps.CardID;
                        inParams.SearchContext = CardProps.CardID;
                        return;
                    }
                }

                if (inParams.bSearchName && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Name)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Name].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.SearchResultSubStrIndex_Name = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Name].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Name;
                        inParams.SearchContext = CardProps.Name;
                        return;
                    }
                }

                if (inParams.bSearchDescription && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Description)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Description].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.SearchResultSubStrIndex_Desc = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Description].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Description;
                        inParams.SearchContext = CardProps.Description;
                        return;
                    }
                }

                if (inParams.bSearchKind && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Kind)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Kind].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Kind].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Kind;
                        inParams.SearchContext = CardProps.Kind;
                        return;
                    }
                }

                if (inParams.bSearchLevel && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Level)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Level].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Level].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Level;
                        inParams.SearchContext = CardProps.Level;
                        return;
                    }
                }

                if (inParams.bSearchATK && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.ATK)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.ATK].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.ATK].Text;
                        CurrentlySelectedSubItem = (int)CardProps.ATK;
                        inParams.SearchContext = CardProps.ATK;
                        return;
                    }
                }

                if (inParams.bSearchDEF && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.DEF)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.DEF].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.DEF].Text;
                        CurrentlySelectedSubItem = (int)CardProps.DEF;
                        inParams.SearchContext = CardProps.DEF;
                        return;
                    }
                }

                if (inParams.bSearchType && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Type)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Type].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Type].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Type;
                        inParams.SearchContext = CardProps.Type;
                        return;
                    }
                }

                if (inParams.bSearchAttr && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Attr)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Attr].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Attr].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Attr;
                        inParams.SearchContext = CardProps.Attr;
                        return;
                    }
                }

                if (inParams.bSearchIcon && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Icon)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Icon].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Icon].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Icon;
                        inParams.SearchContext = CardProps.Icon;
                        return;
                    }
                }

                if (inParams.bSearchRarity && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Rarity)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Rarity].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Rarity].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Rarity;
                        inParams.SearchContext = CardProps.Rarity;
                        return;
                    }
                }

                if (inParams.bSearchPassword && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.Password)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.Password].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.Password].Text;
                        CurrentlySelectedSubItem = (int)CardProps.Password;
                        inParams.SearchContext = CardProps.Password;
                        return;
                    }
                }

                if (inParams.bSearchCardExists && (!((si == CurrentlySelectedItem) && (inParams.SearchContext == CardProps.CardExists)) || bFirstSearch))
                {
                    if (listView.Items[si].SubItems[(int)CardProps.CardExists].Text.ToUpper().Equals(inParams.SearchString.ToUpper()))
                    {
                        inParams.SearchResultIndex = si;
                        inParams.SearchResultSubStrIndex = -1;
                        inParams.ResultString = listView.Items[si].SubItems[(int)CardProps.CardExists].Text;
                        CurrentlySelectedSubItem = (int)CardProps.CardExists;
                        inParams.SearchContext = CardProps.CardExists;
                        return;
                    }
                }
                si++;
            }
        }

        public bool Search(CardSearchParams inParams, ListView listView, bool bNoReset, bool bNoLoop)
        {
            if (listView.SelectedIndices.Count <= 0)
                listView.Items[0].Selected = true;

            if ((CurrentlySelectedItem != listView.SelectedIndices[0]) && !bNoReset) // if we start from a new point, we must reset the virtual subitem selection, otherwise bad things happen...
            {
                CurrentlySelectedItem = listView.SelectedIndices[0];
                CurrentlySelectedSubItem = -1;
                inParams.SearchResultSubStrIndex = -1;
                inParams.SearchResultSubStrIndex_Name = -1;
                inParams.SearchResultSubStrIndex_Desc = -1;
                bFirstSearch = true;
            }

            inParams.SearchResultIndex = -1;
            if (inParams.bMatchWhole)
            {
                if (inParams.bMatchCase)
                    SearchExactCaseSensitive(inParams, listView, bNoLoop);
                else
                    SearchExactCaseless(inParams, listView, bNoLoop);
            }
            else
            {
                if (inParams.bMatchCase)
                    SearchCaseSensitive(inParams, listView, bNoLoop);
                else
                    SearchCaseless(inParams, listView, bNoLoop);
            }

            if (inParams.SearchResultIndex != -1)
            {
                CurrentlySelectedItem = inParams.SearchResultIndex;
                bFirstSearch = false;
                return true;
            }
            else
                return false;
        }
    
        public void Replace(CardSearchParams inParams, TFCard card)
        {
            switch (inParams.SearchContext)
            {
                // comboBoxes
                case CardProps.Kind:
                    card.Kind = (CardKinds)Enum.ToObject(typeof(CardKinds), inParams.ReplaceComboBoxIndex);
                    break;
                case CardProps.Type:
                    card.Type = (CardTypes)Enum.ToObject(typeof(CardTypes), inParams.ReplaceComboBoxIndex);
                    break;
                case CardProps.Attr:
                    card.Attr = (CardAttributes)Enum.ToObject(typeof(CardAttributes), inParams.ReplaceComboBoxIndex);
                    break;
                case CardProps.Icon:
                    card.Icon = (CardIcons)Enum.ToObject(typeof(CardIcons), inParams.ReplaceComboBoxIndex);
                    break;
                case CardProps.Rarity:
                    card.Rarity = (CardRarity)Enum.ToObject(typeof(CardRarity), inParams.ReplaceComboBoxIndex);
                    break;
                case CardProps.CardExists:
                    card.CardExistFlag = Boolean.Parse(inParams.ReplaceString);
                    break;

                // textboxes
                case CardProps.Name:
                    if (inParams.bMatchWhole)
                        card.Name = inParams.ReplaceString;
                    else
                    {
                        string newstr = card.Name.Substring(0, inParams.SearchResultSubStrIndex);
                        newstr += inParams.ReplaceString + card.Name.Substring(inParams.SearchResultSubStrIndex + inParams.SearchString.Length);
                        card.Name = newstr;
                    }
                    break;
                case CardProps.Description:
                    if (inParams.bMatchWhole)
                        card.Description = inParams.ReplaceString;
                    else
                    {
                        string newstr = card.Description.Substring(0, inParams.SearchResultSubStrIndex);
                        newstr += inParams.ReplaceString + card.Description.Substring(inParams.SearchResultSubStrIndex + inParams.SearchString.Length);
                        card.Description = newstr;
                    }
                    break;
                case CardProps.Level:
                    card.Level = Int32.Parse(inParams.ReplaceString);
                    break;
                case CardProps.ATK:
                    card.ATK = Int32.Parse(inParams.ReplaceString);
                    break;
                case CardProps.DEF:
                    card.DEF = Int32.Parse(inParams.ReplaceString);
                    break;
                case CardProps.Password:
                    card.Password = Int32.Parse(inParams.ReplaceString);
                    break;

                default:
                    break;
            }
        }
    }

    public class CardFilterParams
    {
        int p_MinCardID;
        public int MinCardID
        {
            get { return p_MinCardID; }
            set { p_MinCardID = value; }
        }
        int p_MaxCardID;
        public int MaxCardID
        {
            get { return p_MaxCardID; }
            set { p_MaxCardID = value; }
        }


        string p_Name;
        public string Name
        {
            get { return p_Name; }
            set { p_Name = value; }
        }


        int p_MinLevel;
        public int MinLevel
        {
            get { return p_MinLevel; }
            set { p_MinLevel = value; }
        }
        int p_MaxLevel;
        public int MaxLevel
        {
            get { return p_MaxLevel; }
            set { p_MaxLevel = value; }
        }


        int p_MinATK;
        public int MinATK
        {
            get { return p_MinATK; }
            set { p_MinATK = value; }
        }
        int p_MaxATK;
        public int MaxATK
        {
            get { return p_MaxATK; }
            set { p_MaxATK = value; }
        }


        int p_MinDEF;
        public int MinDEF
        {
            get { return p_MinDEF; }
            set { p_MinDEF = value; }
        }
        int p_MaxDEF;
        public int MaxDEF
        {
            get { return p_MaxDEF; }
            set { p_MaxDEF = value; }
        }


        int p_MinPassword;
        public int MinPassword
        {
            get { return p_MinPassword; }
            set { p_MinPassword = value; }
        }
        int p_MaxPassword;
        public int MaxPassword
        {
            get { return p_MaxPassword; }
            set { p_MaxPassword = value; }
        }


        bool[] p_Kind = new bool[(int)CardKinds.Trap + 1]; // todo - adjust this if it grows with newer games...
        public bool[] Kind
        {
            get { return p_Kind; }
            set { p_Kind = value; }
        }

        bool[] p_Type = new bool[(int)CardTypes.Trap + 1];
        public bool[] Type
        {
            get { return p_Type; }
            set { p_Type = value; }
        }

        bool[] p_Attr = new bool[(int)CardAttributes.TRAP + 1];
        public bool[] Attr
        {
            get { return p_Attr; }
            set { p_Attr = value; }
        }

        bool[] p_Icon = new bool[(int)CardIcons.RitualSpell + 1];
        public bool[] Icon
        {
            get { return p_Icon; }
            set { p_Icon = value; }
        }

        bool[] p_Rarity = new bool[(int)CardRarity.UltimateRare + 1];
        public bool[] Rarity
        {
            get { return p_Rarity; }
            set { p_Rarity = value; }
        }

        bool p_CardExists;
        public bool CardExists
        {
            get { return p_CardExists; }
            set { p_CardExists = value; }
        }

        bool p_MatchCase;
        public bool MatchCase
        {
            get { return p_MatchCase; }
            set { p_MatchCase = value; }
        }

        bool p_MatchExact;
        public bool MatchExact
        {
            get { return p_MatchExact; }
            set { p_MatchExact = value; }
        }


        public bool bAreAnyFiltersEnabled_Kind()
        {
            foreach (bool k in Kind)
            {
                if (k)
                    return true;
            }
            return false;
        }

        public bool bAreAnyFiltersEnabled_Type()
        {
            foreach (bool t in Type)
            {
                if (t)
                    return true;
            }
            return false;
        }

        public bool bAreAnyFiltersEnabled_Attr()
        {
            foreach (bool a in Attr)
            {
                if (a)
                    return true;
            }
            return false;
        }

        public bool bAreAnyFiltersEnabled_Icon()
        {
            foreach (bool i in Icon)
            {
                if (i)
                    return true;
            }
            return false;
        }

        public bool bAreAnyFiltersEnabled_Rarity()
        {
            foreach (bool r in Rarity)
            {
                if (r)
                    return true;
            }
            return false;
        }

    }

}
