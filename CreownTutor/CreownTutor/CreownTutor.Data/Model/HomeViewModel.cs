using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Model
{
    public class HomeViewModel
    {
        DataEntities dbEntity = new DataEntities();
        public List<Course> Courses { get { return dbEntity.Courses.ToList(); } }
        public List<AspNetUser> Teachers { get { return dbEntity.AspNetUsers.Where(u => u.AspNetRoles.FirstOrDefault(r => r.Name == "Teacher") != null).ToList(); } }
        public List<AspNetUser> Students { get { return dbEntity.AspNetUsers.Where(u => u.AspNetRoles.FirstOrDefault(r => r.Name == "Student") != null).ToList(); } }
    }
}
