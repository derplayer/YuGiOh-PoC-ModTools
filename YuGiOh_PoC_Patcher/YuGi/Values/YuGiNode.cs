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

        /// <summary>
        /// Name of the node
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }
        /// <summary>
        /// True for making the value readonly
        /// </summary>
        [XmlIgnore]
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// Parent node, null if no parent
        /// </summary>
        [XmlIgnore]
        public YuGiNode Parent { get; set; }

        /// <summary>
        /// Parent of the IChildItem interface
        /// </summary>
        YuGiNode IChildItem<YuGiNode>.Parent
        {
            get { return Parent; }
            set { Parent = value; }
        }

        /// <summary>
        /// Children nodes of the node
        /// </summary>
        public ChildItemCollection<YuGiNode, YuGiNode> Children { get; private set; }

        /// <summary>
        /// Constructor for serialization
        /// </summary>
        public YuGiNode()
        {
            Children = new ChildItemCollection<YuGiNode, YuGiNode>(this);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the node</param>
        public YuGiNode(string name)
        {
            Name = name;
            Children = new ChildItemCollection<YuGiNode, YuGiNode>(this);
        }

        /// <summary>
        /// Returns a node with the given name when existing
        /// </summary>
        /// <typeparam name="T">Type that should be returned</typeparam>
        /// <param name="name">Name of the node that should be searched for</param>
        /// <returns></returns>
        public T GetNode<T>(string name)
        {
            YuGiNode node = Children.FirstOrDefault(n => n.Name == name);
            if (node == null) return default(T);
            return (T)Convert.ChangeType(node, typeof(T));
        }

        /// <summary>
        /// Gets a list of the childrens as YuGiValue's
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Copies the value of another node for all the children nodes
        /// </summary>
        /// <param name="node"></param>
        public virtual void CopyValues(YuGiNode node)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].CopyValues(node.Children[i]);
            }
        }

        /// <summary>
        /// Reads the value from the executable for all the children nodes
        /// </summary>
        /// <param name="reader">BinaryReader that points to the executable</param>
        /// <param name="update"></param>
        public virtual void LoadValues(BinaryReader reader, bool update = false)
        {
            foreach (YuGiNode node in Children)
            {
                node.LoadValues(reader, update);
            }
        }

        /// <summary>
        /// Writes the value to the executable for all the children nodes
        /// </summary>
        /// <param name="writer">BinaryWriter that points to the executable</param>
        public virtual void PatchValues(BinaryWriter writer)
        {
            foreach (YuGiNode node in Children)
            {
                node.PatchValues(writer);
            }
        }

        /// <summary>
        /// BinaryWriter that points to the executable for all the children nodes
        /// </summary>
        /// <param name="writer">BinaryWriter that points to the executable</param>
        public virtual void PatchDefault(BinaryWriter writer)
        {
            foreach (YuGiNode node in Children)
            {
                node.PatchDefault(writer);
            }
        }

        /// <summary>
        /// Writes the value into the memory when the YuGiDebugger is running for all the nodes
        /// </summary>
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
