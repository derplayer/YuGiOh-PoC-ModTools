using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    /// <summary>
    /// List of multiple YuGiValues that will be patched with the same value
    /// </summary>
    public class YuGiValueList : YuGiNode
    {
        [XmlIgnore]
        public byte[] Value
        {
            get
            {
                if (Children.Count == 0) return null;
                return ((YuGiValue)Children[0]).Value;
            }
            set
            {
                foreach (YuGiNode node in Children)
                {
                    ((YuGiValue)node).Value = value;
                }
            }
        }

        [XmlIgnore]
        public Int32 ValueInt32
        {
            get { return BitConverter.ToInt32(Value, 0); }
            set
            {
                Value = BitConverter.GetBytes(value);
                ValuePropertyChanged();
            }
        }

        [XmlIgnore]
        public UInt32 ValueUInt32
        {
            get { return BitConverter.ToUInt32(Value, 0); }
            set
            {
                Value = BitConverter.GetBytes(value);
                ValuePropertyChanged();
            }
        }

        [XmlIgnore]
        public Int16 ValueInt16
        {
            get { return BitConverter.ToInt16(Value, 0); }
            set
            {
                Value = BitConverter.GetBytes(value);
                ValuePropertyChanged();
            }
        }

        [XmlIgnore]
        public UInt16 ValueUInt16
        {
            get { return BitConverter.ToUInt16(Value, 0); }
            set
            {
                Value = BitConverter.GetBytes(value);
                ValuePropertyChanged();
            }
        }

        [XmlIgnore]
        public SByte ValueInt8
        {
            get { return Convert.ToSByte(Value[0]); }
            set
            {
                Value = BitConverter.GetBytes(value);
                ValuePropertyChanged();
            }
        }

        [XmlIgnore]
        public Byte ValueUInt8
        {
            get { return Convert.ToByte(Value[0]); }
            set
            {
                Value = BitConverter.GetBytes(value);
                ValuePropertyChanged();
            }
        }

        [XmlIgnore]
        public string ValueHexLittleEndian
        {
            get { return BitConverter.ToString(Value, 0).Replace("-", ""); }
            set
            {
                if (value.Length > MaxLength * 2 || value.Length % 2 == 1 || !Regex.IsMatch(value, @"\A\b[0-9a-fA-F]+\b\Z")) return;
                Value = new byte[MaxLength];
                for (int i = 0; i < value.Length; i += 2)
                {
                    Value[i / 2] = Convert.ToByte(value.Substring(i, 2), 16); //fix this shit for odd string lengths
                }
                ValuePropertyChanged();
            }
        }

        [XmlIgnore]
        public string ValueHexBigEndian
        {
            get
            {
                string[] splitted = BitConverter.ToString(Value, 0).Split('-');
                return String.Join("", splitted.Reverse());
            }
            set
            {
                if (value.Length > MaxLength * 2 || value.Length % 2 == 1 || !Regex.IsMatch(value, @"\A\b[0-9a-fA-F]+\b\Z")) return;
                Value = new byte[MaxLength];
                for (int i = 0; i < value.Length; i += 2)
                {
                    Value[i / 2] = Convert.ToByte(value.Substring(value.Length - i - 2, 2), 16);
                }
                ValuePropertyChanged();
            }
        }

        [XmlIgnore]
        public string ValueAscii
        {
            get { return Encoding.ASCII.GetString(Value); }
            set
            {
                if (value.Length > 4) return;
                Value = new byte[MaxLength];
                Encoding.ASCII.GetBytes(value).CopyTo(Value, 0);
                ValuePropertyChanged();
            }
        }


        public int MaxLength
        {
            get
            {
                int length = ((YuGiValue)Children[0]).Length;
                foreach (YuGiNode node in Children)
                {
                    YuGiValue value = (YuGiValue)node;
                    if (value.Length < length) length = value.Length;
                }
                return length;
            }
        }

        public YuGiValueList() { }
        public YuGiValueList(string name)
        {
            Name = name;
        }

        private void ValuePropertyChanged()
        {
            OnPropertyChanged("Value");
            OnPropertyChanged("ValueInt32");
            OnPropertyChanged("ValueUInt32");
            OnPropertyChanged("ValueInt16");
            OnPropertyChanged("ValueUInt16");
            OnPropertyChanged("ValueInt8");
            OnPropertyChanged("ValueUInt8");
            OnPropertyChanged("ValueHexLittleEndian");
            OnPropertyChanged("ValueHexBigEndian");
            OnPropertyChanged("ValueAscii");
        }
    }
}
