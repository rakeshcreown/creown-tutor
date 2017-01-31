using CreownTutor.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Model
{
    public class CourseDetailViewModel
    {
        public UserDetail User { get; set; }
        public Course Course { get; set; }
        public List<LiveSession> Sessions { get; set; }
        public List<CourseRegistration> RegisteredUsers { get; set; }
    }
}
