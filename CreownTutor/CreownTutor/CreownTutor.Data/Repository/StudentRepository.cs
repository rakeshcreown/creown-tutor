using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Repository
{
    public class StudentRepository : BaseRepository
    {
        public List<Course> GetLatestCourseByTeacher(string userid)
        {
            return dbEntity.Courses.Where(c => c.CreatedBy == userid).OrderByDescending(c => c.CreatedDateAndTime).ToList();
        }

        public List<Course> GetCourseForStudents(string userid)
        {
            //subscribed courses
            var courses = (from course in dbEntity.Courses
                           join user in dbEntity.CourseRegistrations on course.CourseID equals user.CourseID
                           orderby course.CreatedDateAndTime descending
                           where user.UserID == userid
                           select course).ToList();

            return courses;
        }

        public List<Course> GetCreatedCourses(string userid)
        {
            //created courses
            var createdcourses = dbEntity.Courses.Where(c => c.CreatedBy == userid).OrderByDescending(c => c.CreatedDateAndTime);
            return createdcourses.ToList();
        }

        //public UserDetail GetStudents(int id)
        //{
        //    return dbEntity.UserDetails.FirstOrDefault(m => m.UserID == id);
        //}

        public bool GetEnrolledStudents(string id)
        {
            var value = dbEntity.CourseRegistrations.Where(m => m.UserID == id).Select(m => m.IsEnrolled).Distinct();
            return value != null;
        }

        public List<CourseRegistration> GetRegisteredCourses(bool isEnrolled)
        {
            return dbEntity.CourseRegistrations.Where(c => c.IsEnrolled == true).ToList();
        }
    }
}
