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
        [Required(ErrorMessage ="Username cannot be empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Address cannot be empty")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        public int RoleID { get; set; }
        public SelectList RoleList { get; set; }
    }
}
