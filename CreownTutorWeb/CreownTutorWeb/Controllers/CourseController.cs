using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            bool isenrolled =Convert.ToBoolean(TempData["isenrolled"]);
            return View(courseRepo.GetCourseDetail(id,isenrolled));
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

        [HttpPost]
        public ActionResult Registration(Enrollment model)
        {
            EnrollmentRepository er = new EnrollmentRepository();
            er.Enroll(model);
            TempData["isenrolled"] = true;
            //return RedirectToAction("Detail",new { id = model.Course.CourseID});
            return View("Registration");
        }
    }
}