using CreownTutor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreownTutorWeb
{
    public class SessionManager
    {
        static readonly string SESSION_CurrentUser = "User";
        //public static UserDetail GetSession()
        //{
        //    if (HttpContext.Current.Session != null && HttpContext.Current.Session[SESSION_CurrentUser] != null)
        //    {
        //        return (UserDetail)HttpContext.Current.Session[SESSION_CurrentUser];
        //    }
        //    return null;
        //}

        //public void SetSession(UserDetail userdata)
        //{
        //    HttpContext.Current.Session[SESSION_CurrentUser] = userdata;
        //}
    }
}