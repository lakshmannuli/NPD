using NPD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NPD_UI.Custom
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorization : AuthorizeAttribute
    {
        public string RolesConfigKey { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated && HttpContext.Current.Session["LoggedUser"] != null)
            {
                var loggedUser = HttpContext.Current.Session["LoggedUser"] as LoggedUser;
                if (loggedUser != null)
                {

                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccessDenied", action = "Index", area = "" }));
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", area = "", id = 1 }));
            }
        }
    }
}