using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CreownTutorWeb.Filters
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }

            // Check for authorization
            if (HttpContext.Current.Session["User"] == null)
            {
                RouteValueDictionary rd = new RouteValueDictionary();
                rd.Add("controller", "Account");
                rd.Add("action", "Index");
                filterContext.Result = new RedirectToRouteResult("Default", rd);
                // filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}