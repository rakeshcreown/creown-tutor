using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;

namespace CreownTutorWeb.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index(int id)
        {
            Teacher teacher = new Teacher();
            TeacherRepository teacherrepo = new TeacherRepository();
            teacher.Courses = teacherrepo.GetLatestCourseByTeacher(id);
            teacher.User = teacherrepo.GetTeachers(id);
            teacher.Reviews = teacherrepo.GetReview(id);
            return View(teacher);
        }

        public ActionResult TeacherDashboard(int id = 4)
        {
            Teacher teacher = new Teacher();
            TeacherRepository teacherrepo = new TeacherRepository();
            teacher.Courses = teacherrepo.GetLatestCourseByTeacher(id);
            teacher.User = teacherrepo.GetTeachers(id);
            return View(teacher);
        }
       
        public ActionResult EditProfile(int id = 4)
        {
            Session["user"] = "Teacher";
            Teacher teacher = new Teacher();
            TeacherRepository teacherrepo = new TeacherRepository();
            teacher.User = teacherrepo.GetTeachers(id);
            return View(teacher);
        }

        [HttpPost]
        public ActionResult EditProfile(HttpPostedFileBase file,Teacher model,int id=4)
        {
            Session["user"] = "Teacher";
            Teacher teacher = new Teacher();
            TeacherRepository teacherrepo = new TeacherRepository();
            teacherrepo.UpdateData(file,model,id);
            return View(teacher);
        }
    }
        
}