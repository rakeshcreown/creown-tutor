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
    public class CourseController : Controller
    {
        CourseRepository courseRepo = new CourseRepository();
        // GET: Category
        public ActionResult Index(string cid = "", string s = "")
        {
            CourseViewModel model = new CourseViewModel();
            model.Categories = courseRepo.GetCategories();
            model.Courses = courseRepo.GetCourses(cid, s);
            model.LatestCourses = courseRepo.GetLatestCourse(3);
            model.SearchKeyword = s;
            if (!string.IsNullOrEmpty(cid))
            {
                model.Category = cid;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(CourseViewModel model)
        {
            return RedirectToAction("Index", "Course", new { cid = model.Category, s = model.SearchKeyword });
        }

        public ActionResult Detail(int id)
        {
            string isenrolled = TempData["isenrolled"] != null ? TempData["isenrolled"].ToString() : string.Empty;
            return View(courseRepo.GetCourseDetail(id, isenrolled));
        }

        public ActionResult CreateCourse()
        {
            CourseNewViewModel model = new CourseNewViewModel();
            LoadCategories(model);
            return View(model);
        }

        private void LoadCategories(CourseNewViewModel model)
        {
            var categories = courseRepo.GetCategories();
            model.Categories = new SelectList(categories, "CategoryID", "CategoryName", 0); ;
        }

        [HttpPost]
        public ActionResult CreateCourse(CourseNewViewModel model)
        {
            courseRepo.CreateCourse(model);
            LoadCategories(model);
            return View(model);
        }

        public ActionResult Registration(bool isEnrolled = false, int id = 2)
        {
            Student student = new Student();
            StudentRepository studentrepo = new StudentRepository();
            student.Courses = studentrepo.GetLatestCourseByTeacher(User.Identity.GetUserId());
            student.User = studentrepo.GetStudents(id);
            student.CourseRegistrations = studentrepo.GetRegisteredCourses(isEnrolled);
            return View(student);
        }

        [HttpPost]
        public ActionResult Registration(Enrollment model)
        {
            EnrollmentRepository er = new EnrollmentRepository();
            model.Course.UserID = User.Identity.GetUserId();
            bool enrolled = er.Enroll(model);
            TempData["isenrolled"] = enrolled ? "true" : "enrolled";
            if (User.Identity.IsAuthenticated && !string.IsNullOrEmpty(User.Identity.GetUserId()))
            {
                return RedirectToAction("Detail", new { id = model.Course.CourseID });
            }
            return RedirectToAction("Registration");
        }

        public ActionResult EditCourse(int id = 4, string isenrolled = "true")
        {
            CourseNewViewModel model = new CourseNewViewModel();
            LoadCategories(model);
            courseRepo.GetCourseDetail(id, isenrolled);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourse(CourseNewViewModel model, int id = 4)
        {
            courseRepo.UpdateCourseInfo(model, id);
            return View(model);
        }

        public ActionResult EditCourseList(int id = 4)
        {
            Teacher teacher = new Teacher();
            TeacherRepository teacherrepo = new TeacherRepository();
            teacher.Courses = teacherrepo.GetLatestCourseByTeacher(User.Identity.GetUserId());
            return View(teacher);
        }

        [HttpPost]
        public ActionResult EditCourseList(int id, string name)
        {
            if (name == "edit")
            {
                int courseid = int.Parse(Request["forid"].ToString());
            }
            Teacher teacher = new Teacher();
            return View(teacher);
        }
    }
}