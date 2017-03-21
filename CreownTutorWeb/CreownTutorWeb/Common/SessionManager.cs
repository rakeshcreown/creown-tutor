using CreownTutor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreownTutorWeb
{
    public class SessionManager
    {
        public static UserDetail GetSession()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["User"] != null)
            {
                return (UserDetail)HttpContext.Current.Session["User"];
            }
            return null;
        }

        public static void SetSession(UserDetail userdata)
        {
            HttpContext.Current.Session["User"] = userdata;
        }
    }
}