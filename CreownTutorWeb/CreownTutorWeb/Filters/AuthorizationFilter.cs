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
        static readonly string SESSION_CurrentUser = "User";

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }
            var session = filterContext.HttpContext.Session;
            // Check for authorization
            if (HttpContext.Current.Session[SESSION_CurrentUser] == null)
            {
                RouteValueDictionary rd = new RouteValueDictionary();
                rd.Add("controller", "Account");
                rd.Add("action", "Index");
                filterContext.Result = new RedirectToRouteResult("Default", rd);
                // filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }

    public class AuthorizeActionFilterAttribute : ActionFilterAttribute
    {
        static readonly string SESSION_CurrentUser = "User";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;

            if (controller != null)
            {
                if (session != null && session[SESSION_CurrentUser] == null)
                {
                    filterContext.Result =
                           new RedirectToRouteResult(
                               new RouteValueDictionary{{ "controller", "Account" },
                                          { "action", "Index" }

                                                             });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}