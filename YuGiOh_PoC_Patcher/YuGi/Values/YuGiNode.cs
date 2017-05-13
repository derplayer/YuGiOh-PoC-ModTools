using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    [XmlInclude(typeof(YuGiValue)), XmlInclude(typeof(YuGiValueList)), XmlInclude(typeof(YuGiPoint)), XmlInclude(typeof(YuGiPointBundle)), XmlInclude(typeof(YuGiRectangle))]
    public class YuGiNode : INotifyPropertyChanged, IChildItem<YuGiNode>
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlIgnore]
        public bool IsReadOnly { get; set; }
        [XmlIgnore]
        public YuGiNode Parent { get; set; }

        YuGiNode IChildItem<YuGiNode>.Parent
        {
            get { return Parent; }
            set { Parent = value; }
        }

        public ChildItemCollection<YuGiNode, YuGiNode> Children { get; private set; }

        public YuGiNode()
        {
            Children = new ChildItemCollection<YuGiNode, YuGiNode>(this);
        }

        public YuGiNode(string name)
        {
            Name = name;
            Children = new ChildItemCollection<YuGiNode, YuGiNode>(this);
        }

        public T GetNode<T>(string name)
        {
            YuGiNode node = Children.FirstOrDefault(n => n.Name == name);
            if (node == null) return default(T);
            return (T)Convert.ChangeType(node, typeof(T));
        }

        public List<YuGiValue> GetValues()
        {
            List<YuGiValue> result = new List<YuGiValue>();
            foreach (YuGiNode node in Children)
            {
                if (node.GetType() == typeof(YuGiValue))
                {
                    result.Add((YuGiValue)node);
                }
                else
                {
                    result.AddRange(node.GetValues());
                }
            }
            return result;
        }

        public virtual void CopyValues(YuGiNode node)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].CopyValues(node.Children[i]);
            }
        }

        public virtual void LoadValues(BinaryReader reader, bool update = false)
        {
            foreach (YuGiNode node in Children)
            {
                node.LoadValues(reader, update);
            }
        }

        public virtual void PatchValues(BinaryWriter writer)
        {
            foreach (YuGiNode node in Children)
            {
                node.PatchValues(writer);
            }
        }

        public virtual void PatchDefault(BinaryWriter writer)
        {
            foreach (YuGiNode node in Children)
            {
                node.PatchDefault(writer);
            }
        }

        public virtual void DebugPatchValues()
        {
            foreach (YuGiNode node in Children)
            {
                node.DebugPatchValues();
            }
        }

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == "Value")
            {
                if (Parent != null) Parent.OnPropertyChanged("Value");
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
