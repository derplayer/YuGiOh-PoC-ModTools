using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh_PoC_Patcher.YuGi.Headers;

namespace YuGiOh_PoC_Patcher.YuGi.Filetypes
{
    public class YGAFile
    {
        public string Filename { get; set; }
        public byte[] Data { get; set; }

        public YGAFile(string filename)
        {
            Filename = filename;
        }

        public YGAFile(byte[] data)
        {
            Data = data;
        }

        public static void ConvertToYGA(string inputFilename, string outputFilename)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(outputFilename, FileMode.Create)))
            {
                Bitmap bitmap = new Bitmap(inputFilename);

                YGAHeader header = new YGAHeader();
                header.Width = bitmap.Width;
                header.Height = bitmap.Height;
                header.Mode = 0;
                header.UncompressedSize = bitmap.Width * bitmap.Height * 4; //assuming 32bpp (argb) hue
                header.CompressedSize = 0;
                
                writer.Write(header.GetBytes());

                for (int i = 0; i < bitmap.Height; i++)
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        Color color = bitmap.GetPixel(j, i);
                        writer.Write(color.B);
                        writer.Write(color.G);
                        writer.Write(color.R);
                        writer.Write(color.A);
                    }
                }
            }
        }

        public Bitmap Decompress()
        {
            byte[] buffer;

            if(Data == null) {
                using (BinaryReader reader = new BinaryReader(new FileStream(Filename, FileMode.Open)))
                {
                    buffer = reader.ReadBytes((int)reader.BaseStream.Length - 1);
                }
            }
            else
            {
                buffer = Data;
            }

            byte[] headerBytes = new byte[24];
            Array.Copy(buffer, 0, headerBytes, 0, 24);

            YGAHeader header = YGAHeader.GetHeader(headerBytes);

            byte[] data = new byte[buffer.Length - 23];
            Array.Copy(buffer, 24, data, 0, buffer.Length - 24);

            byte[] bitmapBytes; 
            if (header.Mode == 1)
            {
                bitmapBytes = YuGiLZSS.Decompress(data, header.UncompressedSize);
            }
            else
            {
                bitmapBytes = data;
            }

            Bitmap bitmap = new Bitmap(header.Width, header.Height);
            for (int i = 0; i < header.Height; i++)
            {
                for (int j = 0; j < header.Width; j++)
                {
                    int index = (i * header.Width * 4) + j * 4;
                    Color color = Color.FromArgb(bitmapBytes[index + 3], bitmapBytes[index + 2], bitmapBytes[index + 1], bitmapBytes[index]);
                    bitmap.SetPixel(j, i, color);
                }
            }
            return bitmap;
        }

        public void Decompress(string outputFilename)
        {
            Bitmap bitmap = Decompress();
            bitmap.Save(outputFilename);
        }

    }
}
