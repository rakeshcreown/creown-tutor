using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;
using CreownTutor.Data;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace CreownTutorWeb.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository repo = new AccountRepository();
        // GET: Login
        [HttpGet]
        public ActionResult Index(LoginRegistrationViewModel model = null)
        {
            ModelState.Clear();
            var roles = repo.GetRoles();
            roles.Insert(0, new Role() { RoleID = 0, RoleName = "Select" });
            model.RoleList = new SelectList(roles, "RoleID", "RoleName", 0);

            if (TempData["LoginError"] != null)
            {
                model.ErrorMsg = TempData["LoginError"].ToString();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginRegistrationViewModel model)
        {
            var user = repo.GetUserByUserNameAndPassword(model.LoginUserName, model.LoginPassword);

            if (user == null)
            {
                TempData["LoginError"] = "Invalid Username and Password";
            }
            else
            {
                Session["User"] = user;
                //new SessionManager().SetSession(user);
                switch (user.RoleID)
                {
                    case (int)Enums.Role.Student:
                        return RedirectToAction("Index", "Student");
                    case (int)Enums.Role.Teacher:
                        return RedirectToAction("TeacherDashboard", "teacher");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Registration(LoginRegistrationViewModel model)
        {
            repo.Register(model);
            return RedirectToAction("Index");
        }

        private void SignIn(List<Claim> claims)//Mind!!! This is System.Security.Claims not WIF claims
        {
            var claimsIdentity = new DemoIdentity(claims,
            DefaultAuthenticationTypes.ApplicationCookie);

            //This uses OWIN authentication

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties()
            { IsPersistent = true }, claimsIdentity);

            HttpContext.User = new DemoPrincipal
             (AuthenticationManager.AuthenticationResponseGrant.Principal);
        }
    }
}