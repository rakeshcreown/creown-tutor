using CreownTutor.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Model
{
    public class CourseViewModel
    {
        public List<Course> Courses { get; set; }
        public List<Category> Categories { get; set; }
        public string Category { get; set; }
        public string SearchKeyword { get; set; }
        public List<Course> LatestCourses { get; set; }
    }
}
