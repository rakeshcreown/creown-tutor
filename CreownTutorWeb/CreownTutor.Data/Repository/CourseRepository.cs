using CreownTutor.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreownTutor.Data.Repository
{
    public class CourseRepository : BaseRepository
    {
        public List<Model.Category> GetCategories()
        {
            List<Model.Category> categories = new List<Model.Category>();
            foreach (var item in dbEntity.Categories.ToList())
            {
                int count = 0;
                count = dbEntity.Courses.Where(c => c.Category == item.CategoryID.ToString()).Count();
                categories.Add(new Model.Category() { CategoryID = item.CategoryID.ToString(), CategoryName = item.Category1, CourseCount = count });
            }
            return categories;
        }

        public List<Course> GetCourses(string category = "", string search = "")
        {
            if (!string.IsNullOrEmpty(category))
            {
                return dbEntity.Courses.Where(c => c.Category == category).ToList();
            }
            if (!string.IsNullOrEmpty(search))
            {
                return dbEntity.Courses.Where(c => c.CourseName.Contains(search) || c.CourseDescription.Contains(search)).ToList();
            }
            return dbEntity.Courses.ToList();
        }

        public List<Course> GetLatestCourse(int ct = 0)
        {
            if (ct == 0)
            {
                return dbEntity.Courses.OrderByDescending(c => c.CreatedDateAndTime).ToList();
            }
            return dbEntity.Courses.OrderByDescending(c => c.CreatedDateAndTime).ToList().Take(ct).ToList();
        }

        public CourseDetailViewModel GetCourseDetail(int id)
        {
            CourseDetailViewModel model = new CourseDetailViewModel();
            var course = dbEntity.Courses.FirstOrDefault(c => c.CourseID == id);
            if (course != null)
            {
                model.Course = course;
                model.User = course.UserDetail;
                model.Sessions = dbEntity.LiveSessions.Where(s => s.CourseID == id).ToList();
                model.RegisteredUsers = dbEntity.CourseRegistrations.Where(r => r.CourseID == id).ToList();
            }
            return model;
        }
    }
}
