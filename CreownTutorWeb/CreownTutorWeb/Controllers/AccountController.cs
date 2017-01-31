using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;

namespace CreownTutorWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index(LoginRegistrationViewModel model = null)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginRegistrationViewModel model)
        {
            if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                AccountRepository repo = new AccountRepository();
                repo.Login(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Registration(LoginRegistrationViewModel model)
        {

            AccountRepository repo = new AccountRepository();
            repo.Register(model);
            return RedirectToAction("Index");
        }
    }
}