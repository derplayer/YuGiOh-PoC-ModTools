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
    /// <summary>
    /// Rectangle that contains four YuGiValues
    /// </summary>
    public class YuGiRectangle : YuGiNode
    {
        [XmlIgnore]
        public YuGiValue Left => (YuGiValue)Children[0];
        [XmlIgnore]
        public YuGiValue Top => (YuGiValue)Children[1];
        [XmlIgnore]
        public YuGiValue Right => (YuGiValue)Children[2];
        [XmlIgnore]
        public YuGiValue Bottom => (YuGiValue)Children[3];

        public YuGiRectangle() { }
        public YuGiRectangle(string name, YuGiValue left, YuGiValue top, YuGiValue right, YuGiValue bottom)
        {
            Name = name;
            Children.Add(left);
            Children.Add(top);
            Children.Add(right);
            Children.Add(bottom);
        }

    }
}
