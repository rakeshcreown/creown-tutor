﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreownTutor.Data;
using CreownTutor.Data.Model;
using CreownTutor.Data.Repository;
using PagedList;
using CreownTutorWeb.Filters;

namespace CreownTutorWeb.Controllers
{
    public class TeacherController : BaseController
    {
        TeacherRepository teacherrepo = new TeacherRepository();

        [AuthorizationFilter]
        public ActionResult Index()
        {
            Teacher teacher = new Teacher();
            teacher.Courses = teacherrepo.GetLatestCourseByTeacher(User.UserID);
            teacher.User = User;
            teacher.Reviews = teacherrepo.GetReview(User.UserID);
            return View(teacher);
        }

        [AuthorizeActionFilterAttribute]
        public ActionResult TeacherDashboard()
        {
            Teacher teacher = new Teacher();
            teacher.Courses = teacherrepo.GetLatestCourseByTeacher(User.UserID);
            teacher.User = User;
            return View(teacher);
        }

        [AuthorizationFilter]
        public ActionResult EditProfile()
        {
            Teacher teacher = new Teacher();
            teacher.User = User;
            return View(teacher);
        }

        [HttpPost]
        [AuthorizationFilter]
        public ActionResult EditProfile(HttpPostedFileBase file, Teacher model, int id = 4)
        {
            Teacher teacher = new Teacher();
            teacherrepo.UpdateData(file, model, id);
            return View(teacher);
        }
    }

}