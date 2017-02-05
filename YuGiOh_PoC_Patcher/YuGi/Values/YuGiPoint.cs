using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private YuGiValue _x;
        private YuGiValue _y;

        [XmlIgnore]
        public string Name { get; set; }

        public YuGiValue X
        {
            get { return _x; }
            set
            {
                _x = value;
                if (value == null) return;
                _x.PropertyChanged += ValueChanged;
            }
        }

        public YuGiValue Y
        {
            get { return _y; }
            set
            {
                _y = value;
                if (value == null) return;
                _y.PropertyChanged += ValueChanged;
            }
        }


        public YuGiPoint() { }
        public YuGiPoint(string name, YuGiValue x, YuGiValue y)
        {
            Name = name;
            X = x;
            Y = y;
        }


        /// <summary>
        /// Copies the values of the given instance to the current instance
        /// </summary>
        /// <param name="point"></param>
        public void CopyValues(YuGiPoint point)
        {
            X.CopyValue(point.X);
            Y.CopyValue(point.Y);
        }


        public void LoadValue(BinaryReader reader, bool update = false)
        {
            X.LoadValue(reader, update);
            Y.LoadValue(reader, update);
        }

        public void PatchValue(BinaryWriter writer)
        {
            X.PatchValue(writer);
            Y.PatchValue(writer);
        }

        public void PatchDefault(BinaryWriter writer)
        {
            X.PatchDefault(writer);
            Y.PatchDefault(writer);
        }


        private void ValueChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
