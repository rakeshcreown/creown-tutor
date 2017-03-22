using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Model
{
    public class Category
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CourseCount { get; set; }
        public int TestCount { get; set; }
    }
}
