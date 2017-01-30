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
        public ActionResult Index()
        {
            CourseRepository catRepo = new CourseRepository();
            var categories = catRepo.ShowCategories();
            return View();
        }
    }
}