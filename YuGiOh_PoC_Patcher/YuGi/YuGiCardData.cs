using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi
{
    public enum CardPackType
    {
        Disabled = 0,   //00 00 - disabled
        YugiOnly,       //01 00 - yugi only
        KaibaOnly,      //02 00 - kaiba only
        YugiKaibaOnly,  //03 00 - yugi + kaiba
        JoeyOnly,       //04 00 - joey
        YugiJoeyOnly,   //05 00 - yugi + joey
        KaibaJoeyOnly,  //06 00 - kaiba + joey
        All,            //07 00 - all games
    }

    /// <summary>
    /// For DataGrid view
    /// </summary>
    public class CardPackEntry
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public Bitmap CardImage { get; set; }
        public string CardImageFull { get; set; }
        public CardPackType CardMode { get; set; }
    }

    /// <summary>
    /// card_nameeng.bin - One entry is always 0x40 long.
    /// </summary>
    public class CardNameEntry
    {
        public string Text { get; set; }
        public byte[] Blob { get; set; }
    }

    /// <summary>
    /// list_card.txt
    /// </summary>
    public class CardListEntry
    {
        public string Name { get; set; }
        public string Id { get; set; } // Example: 0001:[1504]
        public string ImageName { get; set; }
    }

    public class YuGiCardData
    {
    }
}
