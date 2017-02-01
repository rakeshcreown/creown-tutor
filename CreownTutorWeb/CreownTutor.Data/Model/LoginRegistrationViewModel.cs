using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CreownTutor.Data.Model
{
    public class LoginRegistrationViewModel
    {
        //Login 
        [Required]
        public string LoginUserName { get; set; }
        [Required]
        public string LoginPassword { get; set; }

        //Registration
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Address cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        public string RegistrationUserName { get; set; }
        [Required]
        public string RegistrationPassword { get; set; }
        [Required]
        public string RegistrationNewPassword { get; set; }
        public int RoleID { get; set; }
        public SelectList RoleList { get; set; }
        public string ErrorMsg { get; set; }
    }
}
