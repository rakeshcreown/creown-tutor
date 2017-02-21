using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;

namespace CreownTutorWeb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(bool isEnrolled,int id=6)
        {
            Session["user"] = "Student";
            Student student = new Student();
            StudentRepository studentrepo = new StudentRepository();
            student.Courses = studentrepo.GetLatestCourseByTeacher(id);
            student.User = studentrepo.GetStudents(id);
            student.CourseRegistrations = studentrepo.GetRegisteredCourses(isEnrolled);
            return View(student);
        }
    }
}