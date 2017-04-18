using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CreownTutor.Data.Model;

namespace CreownTutor.Data.Repository
{
    public class TeacherRepository : BaseRepository
    {
        public List<Course> GetLatestCourseByTeacher(string id)
        {
            return dbEntity.Courses.Where(c => c.CreatedBy == id).OrderByDescending(c => c.CreatedDateAndTime).ToList();
        }

        public List<Course> GetTeacherSubscribedCourses(string id)
        {
            //subscribed courses
            var courses = (from course in dbEntity.Courses
                           join user in dbEntity.CourseRegistrations on course.CourseID equals user.CourseID
                           orderby course.CreatedDateAndTime descending
                           where user.UserID == id
                           select course).ToList();

            return courses;
        }

        //public UserDetail GetTeachers(int id)
        //{
        //    return dbEntity.UserDetails.FirstOrDefault(m => m.UserID == id);
        //}

        public List<Review> GetReview(string userid)
        {
            return dbEntity.Reviews.Where(c => c.UserID == userid).OrderByDescending(c => c.AddedTime).ToList();
        }


        //public UserDetail FileUpload(HttpPostedFileBase file)
        //{

        //        string imagename = System.IO.Path.GetFileName(file.FileName);
        //        string physicalpath = /*Server.MapPath("~/images/" + imagename);*/
        //        System.Web.HttpContext.Current.Server.MapPath("~/images/" + imagename);
        //        file.SaveAs(physicalpath);
        //        UserDetail userinfo = new UserDetail();
        //        userinfo.ProfileImage = imagename;
        //        dbEntity.UserDetails.Add(userinfo);
        //        dbEntity.SaveChanges();
        //    return userinfo;
        //}

        //public void UpdateData(HttpPostedFileBase file, Teacher model, int id)
        //{

        //    try
        //    {


        //        UserDetail userinfo = dbEntity.UserDetails.FirstOrDefault(m => m.UserID == id);
        //        //userinfo.Username = model.User.Username;
        //        if (userinfo != null)
        //        {
        //            userinfo.Name = model.User.Name;
        //            userinfo.EmailAddress = model.User.EmailAddress;
        //            //userinfo.Password = model.User.Password;
        //            userinfo.ContactNumber = model.User.ContactNumber;
        //            userinfo.DateOfBirth = model.User.DateOfBirth;
        //            userinfo.Location = model.User.Location;
        //            userinfo.UpdatedPassword = model.User.UpdatedPassword;
        //            userinfo.Password = model.User.UpdatedPassword;
        //            if (file.ContentLength > 0)
        //            {
        //                var fileName = Path.GetFileName(file.FileName);
        //                var guid = Guid.NewGuid().ToString();
        //                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/uploads"), guid + fileName);
        //                file.SaveAs(path);
        //                string fl = path.Substring(path.LastIndexOf("\\"));
        //                string[] split = fl.Split('\\');
        //                string newpath = split[1];
        //                string imagepath = "~/uploads/" + newpath;
        //                //model.User.Imagelength = imagepath;
        //                userinfo.Imagelength = imagepath;

        //            }
        //            dbEntity.UserDetails.Attach(userinfo);
        //            var entry = dbEntity.Entry(userinfo);
        //            entry.State = EntityState.Modified;
        //            entry.Property(e => e.Name).IsModified = true;
        //            entry.Property(e => e.EmailAddress).IsModified = true;
        //            entry.Property(e => e.ContactNumber).IsModified = true;
        //            entry.Property(e => e.DateOfBirth).IsModified = true;
        //            entry.Property(e => e.Location).IsModified = true;
        //            entry.Property(e => e.UpdatedPassword).IsModified = true;
        //            entry.Property(e => e.Imagelength).IsModified = true;
        //            dbEntity.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //}
    }
}
