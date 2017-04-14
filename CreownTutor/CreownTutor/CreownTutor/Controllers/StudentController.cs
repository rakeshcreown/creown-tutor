using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CreownTutor.Models;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;
using CreownTutor.Data;
namespace CreownTutorWeb.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        StudentRepository studentrepo = new StudentRepository();

        // GET: Student
        public ActionResult Index(int id = 6)
        {
            Student student = new Student();
            student.Courses = studentrepo.GetCourseForStudents(User.Identity.GetUserId());
            student.CreatedCourses = studentrepo.GetCreatedCourses(User.Identity.GetUserId());
            student.User = studentrepo.GetStudents(id);
            return View(student);
        }
    }
}