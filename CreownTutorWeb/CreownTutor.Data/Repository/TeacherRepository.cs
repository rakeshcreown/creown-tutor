using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreownTutor.Data.Model;

namespace CreownTutor.Data.Repository
{
    public class TeacherRepository:BaseRepository
    {
        public List<Course> GetLatestCourseByTeacher(int id)
        {
          return dbEntity.Courses.Where(c => c.CreatedBy == id).OrderByDescending(c=>c.CreatedDateAndTime).ToList();
        }

        public UserDetail GetTeachers(int id)
        {
           
           return dbEntity.UserDetails.FirstOrDefault(m => m.UserID==id);
           
        }

        //public List<Review> GetReview(int userid)
        //{
        //    return dbEntity.Reviews.Where(c=>c.UserID==userid).
        //}
    }
}
