using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiPoint : YuGiNode
    {
        [XmlIgnore]
        public YuGiValue X => (YuGiValue)Children[0];
        [XmlIgnore]
        public YuGiValue Y => (YuGiValue)Children[1];


        public YuGiPoint() { }
        public YuGiPoint(string name, YuGiValue x, YuGiValue y)
        {
            Name = name;
            Children.Add(x);
            Children.Add(y);
        }


    }
}
