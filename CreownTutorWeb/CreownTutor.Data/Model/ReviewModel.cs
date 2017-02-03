using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CreownTutor.Data.Model
{
   public class ReviewModel
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string ReviewComment { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public int SessionID { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
