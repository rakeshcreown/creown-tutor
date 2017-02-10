using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        public List<Review> GetReview(int userid)
        {
            return dbEntity.Reviews.Where(c => c.UserID == userid).OrderByDescending(c => c.AddedTime).ToList();
        }

        public UserDetail FileUpload(HttpPostedFileBase file)
        {
            
                string imagename = System.IO.Path.GetFileName(file.FileName);
                string physicalpath = /*Server.MapPath("~/images/" + imagename);*/
                System.Web.HttpContext.Current.Server.MapPath("~/images/" + imagename);
                file.SaveAs(physicalpath);
                UserDetail userinfo = new UserDetail();
                userinfo.ProfileImage = imagename;
                dbEntity.UserDetails.Add(userinfo);
                dbEntity.SaveChanges();
            return userinfo;
        }

        public void UpdateData(Teacher teacher)
        {
            //UserDetail userinfo = new UserDetail();
            //userinfo.UserID = teacher.User.UserID;
            //userinfo.Name= teacher.User.Name;
            //userinfo.EmailAddress= teacher.User.EmailAddress;
            //userinfo.ContactNumber= teacher.User.ContactNumber;
            //userinfo.DateOfBirth= teacher.User.DateOfBirth;
            //userinfo.Location= teacher.User.Location;
            //dbEntity.Entry(userinfo).State = System.Data.Entity.EntityState.Modified;
            //dbEntity.SaveChanges();

            //var teacherprofile=dbEntity.UserDetails.Where(m=>m.UserID==teacher.User.UserID)
            //if (teacherprofile.Any())
            //{

            //}

        }
    }
}
