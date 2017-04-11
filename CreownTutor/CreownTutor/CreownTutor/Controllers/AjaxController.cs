using CreownTutor.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreownTutor.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendPreNotification(string userid, string courseid)
        {
            EmailRepository repo = new EmailRepository();
            int cid = 0;
            int.TryParse(courseid, out cid);
            repo.SendPreCourseNotification(cid, userid);
            return View();
        }
    }
}