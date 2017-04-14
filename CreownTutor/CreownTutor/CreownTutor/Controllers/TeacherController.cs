using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CreownTutor.Models;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;
using CreownTutor.Data;
namespace CreownTutorWeb.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        TeacherRepository teacherrepo = new TeacherRepository();

        public ActionResult Index()
        {
            Teacher teacher = new Teacher();
            teacher.Courses = teacherrepo.GetLatestCourseByTeacher(User.Identity.GetUserId());
            teacher.Reviews = teacherrepo.GetReview(User.Identity.GetUserId());
            return View(teacher);
        }

        public ActionResult TeacherDashboard()
        {
            Teacher teacher = new Teacher();
            teacher.Courses = teacherrepo.GetLatestCourseByTeacher(User.Identity.GetUserId());
            teacher.MySubscribedCourses = teacherrepo.GetTeacherSubscribedCourses(User.Identity.GetUserId());
            return View(teacher);
        }

        public ActionResult EditProfile()
        {
            return View(new Teacher());
        }

        [HttpPost]
        public ActionResult EditProfile(HttpPostedFileBase file, Teacher model, int id = 4)
        {
            Teacher teacher = new Teacher();
            teacherrepo.UpdateData(file, model, id);
            return View(teacher);
        }
    }

}