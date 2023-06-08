using System;
using System.Text;

namespace YuGiOh_PoC_Patcher.YuGi
{
    /// <summary>
    /// YuGi .dat file entry
    /// </summary>
    public class YuGiDataEntry
    {
        private static readonly Encoding SHIFT_JIS = Encoding.GetEncoding("Shift_JIS");

        public int Offset;
        public int Size;
        public int SizeExtra;
        public string FileName;

        public YuGiDataEntry(byte[] bytes)
        {
            FileName = ConvertToFileName(bytes, 0, 256);
            Offset = BitConverter.ToInt32(bytes, 256);
            Size = BitConverter.ToInt32(bytes, 260);
            SizeExtra = BitConverter.ToInt32(bytes, 264);
        }

        private string ConvertToFileName(byte[] bytes, int index, int length)
        {
            if (index + length > bytes.Length) throw new ArgumentException("Index and/or length is exceeding the given byte array!");
            byte[] result = new byte[256];
            for (int i = index; i < index + length; i++)
            {
                result[i] = (byte)(((bytes[i] & 0xF0) >> 4) | ((bytes[i] & 0x0F) << 4));
            }

            // YuGiOh Online 2004 DATA.DAT:
            // INFO: {Offset: 284891195, Size: 2720312, SizeExtra: 2720312, FileName: y\online\option\option_item01_??.bmp}
            // They really did a typo in SJIS for a filename... so we handle ALL files like SJIS from now on
            var res = SHIFT_JIS.GetString(result, 0, result.Length).Trim('\0');
            return res;
        }

        private byte[] ConvertToBytes(string fileName)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(fileName);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)(((bytes[i] & 0xF0) >> 4) | ((bytes[i] & 0x0F) << 4));
            }
            return bytes;
        }

        public override string ToString()
        {
            return String.Format("Offset: {0}, Size: {1}, SizeExtra: {2}, FileName: {3}", Offset, Size, SizeExtra, FileName);
        }
    }
}