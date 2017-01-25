using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data.Model;

namespace CreownTutorWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginRegistrationViewModel model)
        {

            return RedirectToAction("Index");
        }
        public ActionResult Registration(LoginRegistrationViewModel model)
        {

            return RedirectToAction("Index");
        }
    }
}