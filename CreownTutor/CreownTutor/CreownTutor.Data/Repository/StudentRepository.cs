using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Repository
{
    public class StudentRepository:BaseRepository
    {
        public List<Course> GetLatestCourseByTeacher(int id)
        {
            return dbEntity.Courses.Where(c => c.CreatedBy == id).OrderByDescending(c => c.CreatedDateAndTime).ToList();
        }

        public UserDetail GetStudents(int id)
        {
           return dbEntity.UserDetails.FirstOrDefault(m => m.UserID == id);
        }

        public bool GetEnrolledStudents(int id)
        {
            var value= dbEntity.CourseRegistrations.Where(m => m.UserID == id).Select(m => m.IsEnrolled).Distinct();
            return value != null;
        }

        public List<CourseRegistration> GetRegisteredCourses(bool isEnrolled)
        {
            return dbEntity.CourseRegistrations.Where(c => c.IsEnrolled == true).ToList();
        }
    }
}
