using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi
{
    public static class YuGiLZSS
    {
        public static byte[] Decompress(byte[] data, int length = -1)
        {
            YuGiBuffer yuGiBuffer = new YuGiBuffer(4096, 0xFEE);
            using (MemoryStream writer = new MemoryStream())
            {
                for (int i = 0; i < data.Length; i++)
                {
                    bool[] flags = GetFlags(data[i]);

                    for (int j = 7; j >= 0; j--)
                    {
                        if (flags[j])
                        {
                            if (i + 2 >= data.Length) break;

                            byte[] wordBytes = new byte[2];

                            Array.Copy(data, ++i, wordBytes, 0, 2);
                            YuGiCompressedWord word = new YuGiCompressedWord(wordBytes);

                            byte[] result = yuGiBuffer.GetData(word.Offset, word.Length);
                            i++;

                            writer.Write(result, 0, result.Length);
                            writer.Flush();
                        }
                        else
                        {
                            if (i + 1 >= data.Length) break;

                            writer.Write(data, ++i, 1);
                            writer.Flush();
                            yuGiBuffer.AddData(data[i]);
                        }
                    }
                }
                if (length != -1)
                {
                    if (length > writer.Length)
                    {
                        byte[] padding = new byte[length - writer.Length];
                        writer.Write(padding, 0, padding.Length);
                    }
                }
                return writer.ToArray();
            }
        }

        private static bool[] GetFlags(byte data)
        {
            bool[] result = new bool[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (data & (1 << i)) != 1 << i;
            }
            result = result.Reverse().ToArray();
            return result;
        }
    }
}
