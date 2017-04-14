using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Model
{
    public class Teacher
    {
        public UserDetail User { get; set; }
        public List<Course> Courses { get; set; }
        public List<Course> MySubscribedCourses { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
