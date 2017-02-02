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
        // GET: Category
        public ActionResult Index(string cid = "", string s = "")
        {
            CourseViewModel model = new CourseViewModel();
            CourseRepository catRepo = new CourseRepository();
            model.Categories = catRepo.GetCategories();
            model.Courses = catRepo.GetCourses(cid, s);
            model.LatestCourses = catRepo.GetLatestCourse(3);
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
            CourseRepository courseRepo = new CourseRepository();
            return View(courseRepo.GetCourseDetail(id));
        }

        public ActionResult CreateCourse()
        {
            CourseNewViewModel model = new CourseNewViewModel();
            CourseRepository courseRepo = new CourseRepository();
            var categories = courseRepo.GetCategories();
            model.Categories = new SelectList(categories, "CategoryID", "CategoryName", 0); ;
            return View(model);
        }
    }
}