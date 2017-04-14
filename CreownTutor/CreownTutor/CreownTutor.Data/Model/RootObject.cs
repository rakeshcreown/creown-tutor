using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Model
{
    public class RootObject
    {
        public List<JsonSession> jsondata { get; set; }
    }

    public class JsonSession
    {
        public string name { get; set; }
        public string desc { get; set; }
        public string sdate { get; set; }
        public string enddate { get; set; }
        public string id { get; set; }
    }
}
