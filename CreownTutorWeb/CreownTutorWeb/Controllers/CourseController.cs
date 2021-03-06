﻿using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreownTutorWeb.Controllers
{
    public class CourseController : Controller
    {
        CourseRepository courseRepo = new CourseRepository();
        // GET: Category
        public ActionResult Index(string cid = "", string s = "")
        {
            CourseViewModel model = new CourseViewModel();
            model.Categories = courseRepo.GetCategories();
            model.Courses = courseRepo.GetCourses(cid, s);
            model.LatestCourses = courseRepo.GetLatestCourse(3);
            model.SearchKeyword = s;
            if (!string.IsNullOrEmpty(cid))
            {
                model.Category = cid;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(CourseViewModel model)
        {
            return RedirectToAction("Index", "Course", new { cid = model.Category, s = model.SearchKeyword });
        }

        public ActionResult Detail(int id)
        {
            Session["user"] = "Teacher";
            bool isenrolled =Convert.ToBoolean(TempData["isenrolled"]);
            return View(courseRepo.GetCourseDetail(id,isenrolled));
        }

        public ActionResult CreateCourse()
        {
            CourseNewViewModel model = new CourseNewViewModel();
            LoadCategories(model);
            return View(model);
        }

        private void LoadCategories(CourseNewViewModel model)
        {
            var categories = courseRepo.GetCategories();
            model.Categories = new SelectList(categories, "CategoryID", "CategoryName", 0); ;
        }

        [HttpPost]
        public ActionResult CreateCourse(CourseNewViewModel model)
        {
            courseRepo.CreateCourse(model);
            LoadCategories(model);
            return View(model);
        }

        public ActionResult Registration(bool isEnrolled=false,int id=2)
        {
            Session["user"] = "Student";
            Student student = new Student();
            StudentRepository studentrepo = new StudentRepository();
            student.Courses = studentrepo.GetLatestCourseByTeacher(id);
            student.User = studentrepo.GetStudents(id);
            student.CourseRegistrations = studentrepo.GetRegisteredCourses(isEnrolled);
            return View(student);
        }

        [HttpPost]
        public ActionResult Registration(Enrollment model)
        {
            Session["user"] = "Student";
            EnrollmentRepository er = new EnrollmentRepository();
            er.Enroll(model);
            TempData["isenrolled"] = true;
            //return RedirectToAction("Detail",new { id = model.Course.CourseID});
            //return View("Registration");
            return RedirectToAction("Registration");
        }

        public ActionResult EditCourse(int id=4,bool isenrolled=true)
        {
            CourseNewViewModel model = new CourseNewViewModel();
            LoadCategories(model);
            courseRepo.GetCourseDetail(id, isenrolled);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCourse(CourseNewViewModel model ,int id=4)
        {
            Session["user"] = "Teacher";
            courseRepo.UpdateCourseInfo(model, id);
            return View(model);
        }

        public ActionResult EditCourseList(int id=4)
        {
            Teacher teacher = new Teacher();
            TeacherRepository teacherrepo = new TeacherRepository();
            teacher.Courses = teacherrepo.GetLatestCourseByTeacher(id);
            return View(teacher);
        }

        [HttpPost]
        public ActionResult EditCourseList(int id,string name)
        {
            if(name=="edit")
            {
                int courseid = int.Parse(Request["forid"].ToString());
            }
            Teacher teacher = new Teacher();
            return View(teacher);

        }
    }
}