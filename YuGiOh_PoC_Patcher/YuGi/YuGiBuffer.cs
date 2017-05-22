using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi
{
    /// <summary>
    /// Circular buffer for the LZSS compression
    /// </summary>
    public class YuGiBuffer
    {
        private byte[] _data;
        private int _cursor;
        private int _length;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="length">Length of the buffer/window</param>
        /// <param name="cursorStart">Cursor start offset inside the buffer/window</param>
        public YuGiBuffer(int length, int cursorStart)
        {
            _data = new byte[length];
            _length = length;
            _cursor = cursorStart;
        }

        /// <summary>
        /// Adds a byte to the buffer
        /// </summary>
        /// <param name="value"></param>
        public void AddData(byte value)
        {
            _data[_cursor++] = value;
            _cursor = _cursor & 0xFFF;
        }

        /// <summary>
        /// Gets bytes from the buffer while also filling
        /// the returned bytes into the buffer
        /// </summary>
        /// <param name="offset">Offset inside the buffer/window</param>
        /// <param name="length">Length of how many bytes will be returned</param>
        /// <returns></returns>
        public byte[] GetData(int offset, int length)
        {
            if (offset >= _length) return null;

            byte[] result = new byte[length];

            for (int i = 0; i < length; i++)
            {
                int position = (offset + i) & 0xFFF;
                result[i] = _data[position];
                _data[_cursor++] = _data[position];
                _cursor = _cursor & 0xFFF;
            }
            return result;
        }
    }
}
