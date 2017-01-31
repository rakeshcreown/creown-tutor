using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;
using CreownTutor.Data;

namespace CreownTutorWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index(LoginRegistrationViewModel model = null)
        {
            AccountRepository repo = new AccountRepository();
            var roles = repo.GetRoles();
            Role role = new Role();
            role.RoleName = "Select";
            role.RoleID = 0;
            roles.Insert(0, role);
            SelectList objmodeldata = new SelectList(roles, "RoleID", "RoleName", 0);
            /*Assign value to model*/
            model.RoleList = objmodeldata;
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