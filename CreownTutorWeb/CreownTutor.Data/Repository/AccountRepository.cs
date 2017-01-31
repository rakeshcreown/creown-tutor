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
            try
            {
                UserDetail userdetails = new UserDetail();
                if(userdetails.Username==model.UserName && userdetails.Password==model.Password)
                {
                    FormsAuthentication.SetAuthCookie(userdetails.Username, false);
                    return true;
                }
                else
                {
                    return false;
                }                
            }
           
            catch(Exception e)
            {

            }
            return true;
        }

        public List<Role> GetRoles()
        {
            return dbEntity.Roles.ToList();
        }
    }
}
