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

                //AspNetUser userInformation = new AspNetUser();
                //userInformation.Email = model.RegistrationUserName;
                //userInformation.Email = model.EmailAddress;
                //userInformation.EmailConfirmed= true;

                //userInformation. = model.RegistrationPassword;
                //userInformation.Name = model.Name;
                //userInformation.RoleID = model.RoleID;
                //dbEntity.AspNetUsers.Add(new AspNetUser() {  })
                //dbEntity.UserDetails.Add(userInformation);
                //dbEntity.SaveChanges();
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

        public List<AspNetRole> GetRoles()
        {
            return dbEntity.AspNetRoles.Where(r => r.Name != "Admin").ToList();
        }

        public int GetRoleById(LoginRegistrationViewModel model)
        {
            int query = (from s in dbEntity.Roles
                         join c in dbEntity.UserDetails on s.RoleID equals c.RoleID
                         where c.Username == model.LoginUserName && c.Password == model.LoginPassword
                         select s.RoleID).FirstOrDefault();

            return query;
        }

        public UserDetail GetUserByUserNameAndPassword(string userName, string password)
        {
            return dbEntity.UserDetails.FirstOrDefault(u => u.Username == userName && u.Password == password);
        }
    }
}
