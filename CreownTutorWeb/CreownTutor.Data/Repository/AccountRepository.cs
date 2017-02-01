using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using CreownTutor.Data.Model;

namespace CreownTutor.Data.Repository
{
    public class AccountRepository : BaseRepository
    {
        public void Register(LoginRegistrationViewModel model)
        {
            try
            {
                UserDetail userInformation = new UserDetail();
                userInformation.Username = model.RegistrationUserName;
                userInformation.EmailAddress = model.EmailAddress;
                userInformation.Password = model.RegistrationPassword;
                userInformation.Name = model.Name;
                userInformation.RoleID = model.RoleID;
                dbEntity.UserDetails.Add(userInformation);
                dbEntity.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public bool Login(LoginRegistrationViewModel model)
        {
            var user = dbEntity.UserDetails.FirstOrDefault(u => u.Username == model.LoginUserName && u.Password == model.LoginPassword);
            return user != null;
        }

        public List<Role> GetRoles()
        {
            return dbEntity.Roles.ToList();
        }
    }
}
