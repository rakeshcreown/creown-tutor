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
    
    public partial class LiveSession
    {
        public int SessionID { get; set; }
        public string Title { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan FromTime { get; set; }
        public System.TimeSpan ToTime { get; set; }
        public Nullable<System.DateTime> Timezone { get; set; }
        public bool IsLanguagecgangeable { get; set; }
        public string Description { get; set; }
        public int NoOfAttendees { get; set; }
        public string ClassroomType { get; set; }
        public bool Visibility { get; set; }
        public string TypeOfCourse { get; set; }
        public int UserID { get; set; }
    }
}
