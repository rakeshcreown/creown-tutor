using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreownTutor.Data.Model;

namespace CreownTutor.Data.Repository
{
    public class AccountRepository : BaseRepository
    {
        public void Register(LoginRegistrationViewModel model)
        {
            UserDetail userInformation = new UserDetail();
            userInformation.Username = model.UserName;
            userInformation.EmailAddress = model.EmailAddress;
            userInformation.Password = model.Password;
            userInformation.Name = model.Name;
            dbEntity.UserDetails.Add(userInformation);
            dbEntity.SaveChanges();
        }

        public void Login()
        {

        }
    }
}
