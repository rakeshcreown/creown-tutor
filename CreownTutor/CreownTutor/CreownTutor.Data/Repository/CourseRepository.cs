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

        public CourseNewViewModel GetEditCourseDetail(int id, string isenrolled)
        {
            CourseNewViewModel model = new CourseNewViewModel();
            var course = dbEntity.Courses.FirstOrDefault(c => c.CourseID == id);
            if (course != null)
            {
                model.AttendessLimit = course.AttendessLimit.Value;
                model.CourseName = course.CourseName;
                model.Description = course.CourseDescription;
                model.Category = course.Category;
                model.Price = course.CoursePrice.Value;
                var coursesessions = (from session in course.LiveSessions
                                      select new { CourseID = session.CourseID, Description = session.Description, FromDateTime = session.FromDateTime.Value, ToDateTime = session.ToDateTime.Value, Title = session.Title }).ToList();

                var json = JsonConvert.SerializeObject(coursesessions);
                model.SessionData = json;
            }
            return model;
        }

        public CourseDetailViewModel GetCourseDetail(int id, string isenrolled)
        {
            CourseDetailViewModel model = new CourseDetailViewModel();
            var course = dbEntity.Courses.FirstOrDefault(c => c.CourseID == id);
            if (course != null)
            {
                model.Course = course;
                model.Sessions = dbEntity.LiveSessions.Where(s => s.CourseID == id).ToList();
                model.IsEnrolled = isenrolled;
                model.RegisteredUsers = dbEntity.CourseRegistrations.Where(r => r.CourseID == id).ToList();
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
            course.CreatedBy = model.CurrentUserid;
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
                    session.CreatedDate = System.DateTime.Now;
                    session.CreatedBy = model.CurrentUserid;
                    dbEntity.LiveSessions.Add(session);
                    dbEntity.SaveChanges();
                }
                var coursehours = (Convert.ToDateTime(result.jsondata.Last().enddate) - Convert.ToDateTime(result.jsondata.First().sdate));
                var cr = dbEntity.Courses.FirstOrDefault(c => c.CourseID == course.CourseID);
                if (cr != null)
                {
                    cr.DurationOfCourse = coursehours;
                    dbEntity.SaveChanges();
                }
            }


        }

        public void UpdateCourseInfo(CourseNewViewModel model)
        {
            try
            {
                Course course = dbEntity.Courses.FirstOrDefault(m => m.CourseID == model.CourseID);
                course.CourseName = model.CourseName;
                course.CourseDescription = model.Description;
                course.Category = model.Category;
                //Set current logged in teacher id
                course.CreatedBy = model.CurrentUserid;
                course.CoursePrice = model.Price;
                course.AttendessLimit = model.AttendessLimit;
                course.CreatedDateAndTime = DateTime.Now;
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
                        session.CreatedDate = System.DateTime.Now;
                        session.CreatedBy = model.CurrentUserid;
                        dbEntity.LiveSessions.Add(session);
                        dbEntity.SaveChanges();
                    }
                    var coursehours = (Convert.ToDateTime(result.jsondata.Last().enddate) - Convert.ToDateTime(result.jsondata.First().sdate));
                    var cr = dbEntity.Courses.FirstOrDefault(c => c.CourseID == course.CourseID);
                    if (cr != null)
                    {
                        cr.DurationOfCourse = coursehours;
                        dbEntity.SaveChanges();
                    }
                }

                dbEntity.SaveChanges();
            }
            catch (Exception ex)
            { }
        }
    }
}
