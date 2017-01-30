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

            return View();
        }
    }
}