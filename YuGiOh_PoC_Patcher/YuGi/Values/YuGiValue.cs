using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiValue : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private byte[] _value;

        [XmlIgnore]
        public string Name { get; }
        [XmlIgnore]
        public int Offset { get; }
        [XmlIgnore]
        public int Length { get; }
        [XmlIgnore]
        public byte[] DefaultValue { get; set; }

        [XmlAttribute("Value")]
        public byte[] Value
        {
            get { return _value; }
            set
            {
                if (value == null) return;
                if (Length == 0 || Length == value.Length)
                {
                    _value = value;
                }
                else
                {
                    if (value.Length > Length)
                    {
                        Array.Copy(value, 0, _value, 0, Length);
                    }
                }
                ValuePropertyChanged();
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
                if (value.Length > Length * 2 || value.Length % 2 == 1 || !Regex.IsMatch(value, @"\A\b[0-9a-fA-F]+\b\Z")) return;
                Value = new byte[Length];
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
                if (value.Length > Length * 2 || value.Length % 2 == 1 || !Regex.IsMatch(value, @"\A\b[0-9a-fA-F]+\b\Z")) return;
                Value = new byte[Length];
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
                Value = new byte[Length];
                Encoding.ASCII.GetBytes(value).CopyTo(Value, 0);
                ValuePropertyChanged();
            }
        }

        /// <summary>
        /// Serializer Constructor
        /// </summary>
        public YuGiValue() { }

        public YuGiValue(string name, int offset, byte[] defaultValue)
        {
            Name = name;
            Offset = offset;
            Length = defaultValue.Length;
            DefaultValue = defaultValue;
            Value = defaultValue;
        }

        public void CopyValue(YuGiValue value)
        {
            if (Length != value.Value.Length)
            {
                throw new ArgumentException("The given value has an different length!");
            }
            Value = value.Value;
        }

        public void LoadValue(BinaryReader reader, bool update = false)
        {
            reader.BaseStream.Seek(Offset, SeekOrigin.Begin);
            Value = reader.ReadBytes(Length);

            Console.WriteLine(ToString());

            if (!update) return;
            ValuePropertyChanged();
        }

        public void PatchValue(BinaryWriter writer)
        {
            writer.Seek(Offset, SeekOrigin.Begin);
            writer.Write(Value, 0, Length);
        }

        public void PatchDefault(BinaryWriter writer)
        {
            writer.Seek(Offset, SeekOrigin.Begin);
            writer.Write(DefaultValue, 0, Length);
        }

        public override string ToString()
        {
            return String.Format("{0}: 0x{1} ({2})", Name, ValueHexLittleEndian, ValueInt32);
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

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
