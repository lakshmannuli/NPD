using NPD.DAL.Repositories;
using NPD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NPD_UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDTO model)
        {
            try
            {
                var user = UsersinfoRepository.ValidateUser(new NPD.DAL.EntityFramework.UsersInfo() { Email = model.UserName, Password = model.Password });
                if (user == null)
                {
                    ViewBag.Message = "Invalid username or password";
                    ViewBag.IsError = true;
                    return View();
                }
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                FormsAuthentication.RedirectFromLoginPage(model.UserName, model.RememberMe);
                var loggedUser = new LoggedUser()
                {
                    Id = user.Id,
                    Name = user.Name,
                    RoleId = Convert.ToInt32(user.RoleId),
                    UserName = user.Email,
                    Password = model.Password
                };
                Session["LoggedUser"] = loggedUser;
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Failed to validate details";
                ViewBag.IsError = true;
            }
            return View();
        }
    }
}