using CreownTutor.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data.Model;

namespace CreownTutorWeb.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveRating(ReviewModel model)
        {
            ReviewRepository review = new ReviewRepository();
             
            int result = review.saverating(model);
            
           
            return RedirectToAction("Index");
        }
    }
}