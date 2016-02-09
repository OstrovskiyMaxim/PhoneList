using Newtonsoft.Json;
using PhoneList.Models;
using PhoneList.Models.ViewModels;
using PhoneList.Security;
using PhoneList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PhoneList.Controllers
{
    public class AccountController : Controller
    {
        UserService service = new UserService();
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = service.GetAllUsers().FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                if (user!=null)
                {
                    var role = new string[1];
                    role.SetValue(user.Role, 0);

                    var cookie = Register(role, user);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("AddressBook", "Main", user.Id);
                    
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect username or password");
                return View(model);
            }
        }

        [CustomAuthorize(Roles = "user,admin")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Main");
        }

        private static HttpCookie Register(string[] role,UserViewModel user)
        {
            var serializeModel = new CustomPrincipalSerializeModel(user.Id, user.Login, role);
            var userData = JsonConvert.SerializeObject(serializeModel);
            var authTicket = new FormsAuthenticationTicket(1, user.Login, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
            var encryptTicket = FormsAuthentication.Encrypt(authTicket);
            return new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Role = "user";
                service.Create(model);
                return RedirectToAction("Login", "Account", model);
            }
            else
            {
                return View(model);
            }
        }
    }
}