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
                userInformation.Username = model.UserName;
                userInformation.EmailAddress = model.EmailAddress;
                userInformation.Password = model.Password;
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
            var user = (from userlist in dbEntity.UserDetails
                        where userlist.Username == model.UserName && userlist.Password == model.Password
                        select new
                        {
                            userlist.Username,
                            userlist.UserID
                        }).ToList();

            if(user.FirstOrDefault()!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Role> GetRoles()
        {
            return dbEntity.Roles.ToList();
        }
    }
}
