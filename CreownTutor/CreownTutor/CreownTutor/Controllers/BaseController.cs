using CreownTutor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreownTutorWeb.Controllers
{
    public class BaseController : Controller
    {
        public UserDetail User { get; set; }

        public BaseController()
        {
            this.User = SessionManager.GetSession();
        }
    }
}