using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;

namespace CreownTutorWeb.Controllers
{
    public class TestController : Controller
    {
        TestRepository repo = new TestRepository();
        // GET: Test
        public ActionResult CreateTest()
        {
            var listhour = new List<int>();
            for(int i=0; i < 24 ;i++)
            {
                listhour.Add(i);
            }
            SelectList selectedlist = new SelectList(listhour);
            ViewBag.ddlist =selectedlist;
            TestViewModel test = new TestViewModel();
            LoadCategories(test);
            return View(test);
        }

        //Fo loading categories in the test page category dropdown
        private void LoadCategories(TestViewModel model)
        {
            var categories = repo.GetCategories();
            model.Categories= new SelectList(categories, "CategoryID", "CategoryName", 0);
        }

        [HttpPost]
        public ActionResult CreateTest(TestViewModel test)
        {
            repo.CreateTest(test);
            LoadCategories(test);
            return View(test);

        }
    }
}