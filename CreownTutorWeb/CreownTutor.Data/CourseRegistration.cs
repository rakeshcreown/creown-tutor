//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CreownTutor.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseRegistration
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> RegisteredDateTime { get; set; }
        public Nullable<bool> IsEnrolled { get; set; }
    
        public virtual UserDetail UserDetail { get; set; }
    }
}
