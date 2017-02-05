using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiValueList : List<YuGiValue>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public byte[] Value
        {
            get
            {
                if (Count == 0) return null;
                return this[0].Value;
            }
            set
            {
                foreach (YuGiValue val in this)
                {
                    val.Value = value;
                }
                OnPropertyChanged("Value");
            }
        }
        public YuGiValueList() {}

        public YuGiValueList(List<YuGiValue> list)
        {
            foreach (YuGiValue value in list)
            {
                value.PropertyChanged += ValueChanged;
                Add(value);
            }
        }

        public void CopyValues(YuGiValueList list)
        {
            if (list.Count != Count) return;
            for (int i = 0; i < Count; i++)
            {
                this[i].CopyValue(list[i]);
            }
        }

        public void LoadValue(BinaryReader reader, bool update = false)
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].LoadValue(reader, update);
            }
        }

        public void PatchValue(BinaryWriter writer)
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].PatchValue(writer);
            }
        }

        public void PatchDefault(BinaryWriter writer)
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].PatchDefault(writer);
            }
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
