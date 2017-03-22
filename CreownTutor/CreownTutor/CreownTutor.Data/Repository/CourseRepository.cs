using CreownTutor.Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public CourseDetailViewModel GetCourseDetail(int id,bool isenrolled)
        {
            CourseDetailViewModel model = new CourseDetailViewModel();
            var course = dbEntity.Courses.FirstOrDefault(c => c.CourseID == id);
            if (course != null)
            {
                model.Course = course;
                model.User = course.UserDetail;
                model.Sessions = dbEntity.LiveSessions.Where(s => s.CourseID == id).ToList();
                model.IsEnrolled = isenrolled;
                // TODO - Registered users will be shown only to Teacher Account
                //model.RegisteredUsers = dbEntity.CourseRegistrations.Where(r => r.CourseID == id).ToList();
            }
            return model;
        }

        public void CreateCourse(CourseNewViewModel model)
        {
            Course course = new Course();
            course.CourseName = model.CourseName;
            course.CourseDescription = model.Description;
            course.Category = model.Category;
            //Set current logged in teacher id
            //course.CreatedBy =
            course.CoursePrice = model.Price;
            course.AttendessLimit = model.AttendessLimit;
            course.CreatedDateAndTime = DateTime.Now;
            dbEntity.Courses.Add(course);
            dbEntity.SaveChanges();

            var result = JsonConvert.DeserializeObject<RootObject>(model.SessionData);
            if (result != null && result.jsondata.Count > 0)
            {
                foreach (var item in result.jsondata)
                {
                    LiveSession session = new LiveSession();
                    session.CourseID = course.CourseID;
                    session.Description = item.desc;
                    session.FromDateTime = Convert.ToDateTime(item.sdate);
                    session.ToDateTime = Convert.ToDateTime(item.enddate);
                    session.Title = item.name;
                    dbEntity.LiveSessions.Add(session);
                    dbEntity.SaveChanges();
                }
            }

        }

        public void UpdateCourseInfo(CourseNewViewModel model,int id)
        {
            try
            {
                Course course = dbEntity.Courses.FirstOrDefault(m => m.CourseID == id);
                course.CourseName = model.CourseName;
                course.CourseDescription = model.Description;
                //course.Category = model.Category;
                course.CoursePrice = model.Price;
                course.AttendessLimit = model.AttendessLimit;
                course.CreatedDateAndTime = DateTime.Now;
                dbEntity.Courses.Attach(course);
                var entry = dbEntity.Entry(course);
                entry.State = EntityState.Modified;
                entry.Property(e => e.CourseName).IsModified = true;
                entry.Property(e => e.CourseDescription).IsModified = true;
                //entry.Property(e => e.Category).IsModified = true;
                entry.Property(e => e.CoursePrice).IsModified = true;
                entry.Property(e => e.AttendessLimit).IsModified = true;
                entry.Property(e => e.CreatedDateAndTime).IsModified = true;
                dbEntity.SaveChanges();
            }
            catch(Exception ex)
            { }
        }
    }
}
