using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiRectangle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private YuGiValue _left;
        private YuGiValue _top;
        private YuGiValue _right;
        private YuGiValue _bottom;

        [XmlIgnore]
        public string Name { get; set; }

        public YuGiValue Left
        {
            get { return _left; }
            set
            {
                _left = value;
                if (value == null) return;
                _left.PropertyChanged += ValueChanged;
            }
        }

        public YuGiValue Top
        {
            get { return _top; }
            set
            {
                _top = value;
                if (value == null) return;
                _top.PropertyChanged += ValueChanged;
            }
        }

        public YuGiValue Right
        {
            get { return _right; }
            set
            {
                _right = value;
                if (value == null) return;
                _right.PropertyChanged += ValueChanged;
            }
        }

        public YuGiValue Bottom
        {
            get { return _bottom; }
            set
            {
                _bottom = value;
                if (value == null) return;
                _bottom.PropertyChanged += ValueChanged;
            }
        }

        public YuGiRectangle() { }
        public YuGiRectangle(string name, YuGiValue left, YuGiValue top, YuGiValue right, YuGiValue bottom)
        {
            Name = name;
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public void CopyValues(YuGiRectangle rectangle)
        {
            Left.CopyValue(rectangle.Left);
            Top.CopyValue(rectangle.Top);
            Right.CopyValue(rectangle.Right);
            Bottom.CopyValue(rectangle.Bottom);
        }


        public void LoadValue(BinaryReader reader, bool update = false)
        {
            Left.LoadValue(reader, update);
            Top.LoadValue(reader, update);
            Right.LoadValue(reader, update);
            Bottom.LoadValue(reader, update);
        }

        public void PatchValue(BinaryWriter writer)
        {
            Left.PatchValue(writer);
            Top.PatchValue(writer);
            Right.PatchValue(writer);
            Bottom.PatchValue(writer);
        }

        public void PatchDefault(BinaryWriter writer)
        {
            Left.PatchDefault(writer);
            Top.PatchDefault(writer);
            Right.PatchDefault(writer);
            Bottom.PatchDefault(writer);
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
