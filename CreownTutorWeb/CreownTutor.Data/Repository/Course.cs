//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CreownTutor.Data.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int NoOfChapters { get; set; }
        public System.DateTime DurationOfCourse { get; set; }
        public int NoOfAttendees { get; set; }
        public string TypeOfCourse { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public byte[] ContentType { get; set; }
        public System.DateTime CreatedDateAndTime { get; set; }
        public int RoleID { get; set; }
    }
}
