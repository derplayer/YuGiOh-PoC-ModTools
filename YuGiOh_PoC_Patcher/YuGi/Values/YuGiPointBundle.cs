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
    public class YuGiPointBundle : YuGiNode
    {
        private int _gap;

        public int Gap
        {
            get { return _gap; }
            set
            {
                _gap = value;
                UpdateValues();
            }
        }

        public YuGiPointBundle() { }

        public YuGiPointBundle(string name, int gap)
        {
            Name = name;
            Gap = gap;
        }

        private void UpdateValues()
        {
            if (Children.Count < 2) return;
            YuGiPoint basePoint = (YuGiPoint)Children[0];
            for (int i = 1; i < Children.Count; i++)
            {
                YuGiPoint point = (YuGiPoint)Children[i];
                point.X.ValueInt32 = basePoint.X.ValueInt32 + i * Gap;
                point.Y.ValueInt32 = basePoint.Y.ValueInt32;
            }
        }

        public override void CopyValues(YuGiNode pointBundle)
        {
            Gap = ((YuGiPointBundle)pointBundle).Gap;
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].CopyValues(pointBundle.Children[i]);
            }
        }

        public override void LoadValues(BinaryReader reader, bool update = false)
        {
            foreach (YuGiNode point in Children)
            {
                point.LoadValues(reader, update);
            }
            Gap = ((YuGiPoint)Children[1]).X.ValueInt32 - ((YuGiPoint)Children[0]).X.ValueInt32;
        }
    }
}
