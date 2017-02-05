using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi
{
    public class YuGiBuffer
    {
        private byte[] _data;
        private int _cursor;
        private int _length;

        public YuGiBuffer(int length, int cursorStart)
        {
            _data = new byte[length];
            _length = length;
            _cursor = cursorStart;
        }

        public void AddData(byte value)
        {
            _data[_cursor++] = value;
            _cursor = _cursor & 0xFFF;
        }

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
