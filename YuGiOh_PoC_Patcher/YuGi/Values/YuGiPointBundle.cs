using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    /// <summary>
    /// First cards coordinates and a gap in pixels is used to generate the other cards coordinates
    /// </summary>
    public class YuGiPointBundle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private YuGiPoint[] _points;
        private int _gap;

        [XmlIgnore]
        public string Name { get; set; }

        public YuGiPoint[] Points
        {
            get { return _points; }
            set
            {
                _points = value;
                if (value == null) return;
                foreach (YuGiPoint point in _points)
                {
                    point.PropertyChanged += ValueChanged;
                }
            }
        }

        public int Gap
        {
            get { return _gap; }
            set
            {
                _gap = value;
                UpdateValues();
            }
        }    

        private void UpdateValues()
        {
            if (Points == null) return;
            if (Points.Length < 2) return;
            for (int i = 1; i < Points.Length; i++)
            {
                YuGiPoint point = Points[i];
                point.X.ValueInt32 = Points[0].X.ValueInt32 + i * Gap;
                point.Y.ValueInt32 = Points[0].Y.ValueInt32;
            }
        }

        /// <summary>
        /// Copies the values of the given instance to the current instance
        /// </summary>
        /// <param name="pointBundle"></param>
        public void CopyValues(YuGiPointBundle pointBundle)
        {
            Gap = pointBundle.Gap;
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].CopyValues(pointBundle.Points[i]);
            }
        }

        public void LoadValue(BinaryReader reader, bool update = false)
        {
            foreach (YuGiPoint point in Points)
            {
                point.LoadValue(reader, update);
            }

            Gap = Points[1].X.ValueInt32 - Points[0].X.ValueInt32;
            OnPropertyChanged();
        }

        public void PatchValue(BinaryWriter writer)
        {
            foreach (YuGiPoint point in Points)
            {
                point.PatchValue(writer);
            }
        }

        public void PatchDefault(BinaryWriter writer)
        {
            foreach (YuGiPoint point in Points)
            {
                point.PatchDefault(writer);
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
