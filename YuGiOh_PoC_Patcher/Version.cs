using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace YuGiOh_PoC_Patcher
{
    public static class Version
    {
        //Version
        public static double actualVerison = 1.1;
        public static string urlversion = "http://goo.gl/9BQohW";
    }

    [DataContract]
    public class Version_JSON
    {
        [DataMember]
        public double newestVersion { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string message { get; set; }
    }

    }
