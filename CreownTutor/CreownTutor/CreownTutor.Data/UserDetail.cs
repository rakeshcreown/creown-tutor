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
    
    public partial class UserDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDetail()
        {
            this.Reviews = new HashSet<Review>();
        }
    
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string ContactDetails { get; set; }
        public string DateOfBirth { get; set; }
        public int RoleID { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ExperienceInfo { get; set; }
        public string BioGraphInfo { get; set; }
        public string UpdatedPassword { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Imagelength { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
