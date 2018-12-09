using NPD_UI.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPD_UI.Controllers
{
    public class BaseController : Controller
    {
        public SessionStore CurrentSession
        {
            set;
            get;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.ControllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            this.CurrentSession = (new SessionStore(HttpContext.Session));
        }
    }
}