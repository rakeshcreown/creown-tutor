using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CreownTutor.Data.Model
{
    public class CourseNewViewModel
    {
        [Required]
        public string CourseName { get; set; }

        [Required]
        public string Description { get; set; }

        public int NoOfChapter { get; set; }

        [Required]
        public int DurationOfCourse { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Category { get; set; }

        public string Tags { get; set; }

        public int AttendessLimit { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public SelectList Categories { get; set; }

        public string SessionData { get; set; }

        public string CurrentUserid { get; set; }

        public int CourseID { get; set; }
    }
}
