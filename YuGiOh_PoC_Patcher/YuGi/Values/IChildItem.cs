using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public interface IChildItem<P> where P : class
    {
        P Parent { get; set; }
    }
}
