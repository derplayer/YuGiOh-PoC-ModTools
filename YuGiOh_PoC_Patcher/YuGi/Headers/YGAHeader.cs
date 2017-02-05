using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi.Headers
{
    public class YGAHeader
    {
        public static byte[] Identifier => new byte[] { 0x79, 0x67, 0x61, 0x00 };

        public int Width { get; set; }
        public int Height { get; set; }
        public int Mode { get; set; }
        public int UncompressedSize { get; set; }
        public int CompressedSize { get; set; }

        public byte[] GetBytes()
        {
            byte[] result = new byte[24];

            Identifier.CopyTo(result, 0);
            BitConverter.GetBytes(Width).CopyTo(result, 0x04);
            BitConverter.GetBytes(Height).CopyTo(result, 0x08);
            BitConverter.GetBytes(Mode).CopyTo(result, 0x0C);
            BitConverter.GetBytes(UncompressedSize).CopyTo(result, 0x10);
            BitConverter.GetBytes(CompressedSize).CopyTo(result, 0x14);

            return result;
        }

        public static YGAHeader GetHeader(byte[] data)
        {
            byte[] header = new byte[4];
            Array.Copy(data, 0, header, 0, 4);
            if (!header.SequenceEqual(Identifier)) return null;

            YGAHeader result = new YGAHeader
            {
                Width = BitConverter.ToInt32(data, 0x04),
                Height = BitConverter.ToInt32(data, 0x08),
                Mode = BitConverter.ToInt32(data, 0x0C),
                UncompressedSize = BitConverter.ToInt32(data, 0x10),
                CompressedSize = BitConverter.ToInt32(data, 0x14)
            };

            return result;
        }

    }
}
