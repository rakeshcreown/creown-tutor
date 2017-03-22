using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CreownTutor.Data.Model
{
   public class TestViewModel
    {
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public string Category { get; set; }
        public string TestInstructions { get; set; }
        public bool AllowViewingAnswer { get; set; }
        public bool IsTimeAlloted { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Marks { get; set; }
        public decimal Percentage { get; set; }
        public bool Result { get; set; }
        public bool Payment { get; set; }
        public int UserID { get; set; }

        public SelectList Categories { get; set; }

    }
}
