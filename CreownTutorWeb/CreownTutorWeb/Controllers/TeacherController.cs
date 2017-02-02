using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            teacher.Courses=teacherrepo.GetLatestCourseByTeacher(id);
            teacher.User=teacherrepo.GetTeachers(id);
            return View(teacher);
        }

    }
}