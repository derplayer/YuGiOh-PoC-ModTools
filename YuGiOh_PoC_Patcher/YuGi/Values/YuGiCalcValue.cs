using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiCalcValue : YuGiValue
    {
        public YuGiCalcValue(Func<int, int> expression)
        {
            //expression.Invoke(Parent.Value);
        }
    }
}
