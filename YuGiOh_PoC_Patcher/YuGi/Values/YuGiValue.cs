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
    public class YuGiValue : YuGiNode
    {
        /// <summary>
        /// debugLog?
        /// </summary>
        public static List<string> debugLog;

        private byte[] _value;

        /// <summary>
        /// Offset inside the executable
        /// </summary>
        [XmlAttribute("Offset")]
        public int Offset { get; set; }
        /// <summary>
        /// Length of the value in bytes
        /// </summary>
        [XmlIgnore]
        public int Length { get; }
        /// <summary>
        /// Default value
        /// </summary>
        [XmlIgnore]
        public byte[] DefaultValue { get; set; }
        /// <summary>
        /// [UNUSED] Concept not fleshed out
        /// </summary>
        [XmlIgnore]
        Func<int, int> Expression { get; set; }

        /// <summary>
        /// Value that will be patched to executable.
        /// When setting the value all children will be patched with the same value
        /// </summary>
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

                if (Children.Count != 0)
                {
                    foreach (YuGiNode node in Children)
                    {
                        if (node.GetType() != typeof(YuGiValue)) continue;
                        YuGiValue valueNode = (YuGiValue)node;
                        valueNode.Value = _value;
                    }
                }
            }
        }

        [XmlIgnore]
        public Int32 ValueInt32
        {
            get { return BitConverter.ToInt32(Value, 0); }
            set { Value = BitConverter.GetBytes(value); }
        }

        [XmlIgnore]
        public UInt32 ValueUInt32
        {
            get { return BitConverter.ToUInt32(Value, 0); }
            set { Value = BitConverter.GetBytes(value); }
        }

        [XmlIgnore]
        public Int16 ValueInt16
        {
            get { return BitConverter.ToInt16(Value, 0); }
            set { Value = BitConverter.GetBytes(value); }
        }

        [XmlIgnore]
        public UInt16 ValueUInt16
        {
            get { return BitConverter.ToUInt16(Value, 0); }
            set { Value = BitConverter.GetBytes(value); }
        }

        [XmlIgnore]
        public SByte ValueInt8
        {
            get { return Convert.ToSByte(Value[0]); }
            set { Value = BitConverter.GetBytes(value); }
        }

        [XmlIgnore]
        public Byte ValueUInt8
        {
            get { return Convert.ToByte(Value[0]); }
            set { Value = BitConverter.GetBytes(value); }
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
            }
        }



        /// <summary>
        /// Serializer Constructor
        /// </summary>
        public YuGiValue() { }

        public YuGiValue(string name, int offset, byte[] defaultValue, bool readOnly = false)
        {
            Name = name;
            Offset = offset;
            Length = defaultValue.Length;
            DefaultValue = defaultValue;
            Value = defaultValue;
            IsReadOnly = readOnly;
        }

        /// <summary>
        /// [UNUSED] Concept not fleshed out
        /// </summary>
        /// <param name="name"></param>
        /// <param name="offset"></param>
        /// <param name="defaultValue"></param>
        /// <param name="expression"></param>
        public YuGiValue(string name, int offset, byte[] defaultValue, Func<int, int> expression)
        {
            Name = name;
            Offset = offset;
            Length = defaultValue.Length;
            DefaultValue = defaultValue;
            Value = defaultValue;
            Expression = expression;
            IsReadOnly = true;
        }

        /// <summary>
        /// [OUTDATED]
        /// </summary>
        /// <param name="name"></param>
        /// <param name="offset"></param>
        /// <param name="defaultValue"></param>
        /// <param name="eventHandler"></param>
        public YuGiValue(string name, int offset, byte[] defaultValue, PropertyChangedEventHandler eventHandler)
        {
            Name = name;
            Offset = offset;
            Length = defaultValue.Length;
            DefaultValue = defaultValue;
            Value = defaultValue;
            PropertyChanged += eventHandler;
            IsReadOnly = true;
        }

        /// <summary>
        /// Copies the value of another YuGiValue
        /// </summary>
        /// <param name="value">The YuGiValue that will be copied from</param>
        public override void CopyValues(YuGiNode value)
        {
            YuGiValue val = (YuGiValue)value;
            if (Length != val.Value.Length)
            {
                throw new ArgumentException("The given value has an different length!");
            }
            base.CopyValues(value);
            Value = val.Value; //overrides the children values by setting the value
        }

        /// <summary>
        /// Reads the value from the executable
        /// </summary>
        /// <param name="reader">BinaryReader that points to the executable</param>
        /// <param name="update"></param>
        public override void LoadValues(BinaryReader reader, bool update = false)
        {
            base.LoadValues(reader, update);
            reader.BaseStream.Seek(Offset, SeekOrigin.Begin);
            Value = reader.ReadBytes(Length); //overrides the children values by setting the value
            
            Console.WriteLine(ToString());
        }

        /// <summary>
        /// Writes the value to the executable
        /// </summary>
        /// <param name="writer">BinaryWriter that points to the executable</param>
        public override void PatchValues(BinaryWriter writer)
        {
            writer.Seek(Offset, SeekOrigin.Begin);
            writer.Write(Value, 0, Length);

            base.PatchValues(writer);
        }

        /// <summary>
        /// Writes the default value to the executable
        /// </summary>
        /// <param name="writer">BinaryWriter thats points to the executable</param>
        public override void PatchDefault(BinaryWriter writer)
        {
            writer.Seek(Offset, SeekOrigin.Begin);
            writer.Write(DefaultValue, 0, Length);

            base.PatchDefault(writer);
        }

        /// <summary>
        /// Writes the value into the memory when the YuGiDebugger is running
        /// </summary>
        public override void DebugPatchValues()
        {
            YuGiDebugger.PatchMemory(this);
            base.DebugPatchValues();
        }

        public override string ToString()
        {
            if (Length == 4) return String.Format("[{0}] {1}: 0x{2} ({3})", Offset.ToString("X8"), Name, ValueHexLittleEndian, ValueInt32);
            if (Length == 2) return String.Format("[{0}] {1}: 0x{2} ({3})", Offset.ToString("X8"), Name, ValueHexLittleEndian, ValueInt16);
            if (Length == 1) return String.Format("[{0}] {1}: 0x{2} ({3})", Offset.ToString("X8"), Name, ValueHexLittleEndian, ValueInt8);

            string finalString = String.Format("[{0}] {1}: 0x{2}", Offset.ToString("X8"), Name, ValueHexLittleEndian);
            debugLog.Add(DateTime.Now.ToString() + " | " + finalString);
            return finalString;
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

            if (Parent != null) Parent.OnPropertyChanged("Value");

            DebugPatchValues();
        }
    }
}
