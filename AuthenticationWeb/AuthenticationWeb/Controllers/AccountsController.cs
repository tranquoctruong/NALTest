using AuthenticationBusiness.UserBusiness;
using AuthenticationWeb.Common;
using AuthenticationWeb.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using AuthenticationWeb.CustomAttribute;

namespace AuthenticationWeb.Controllers
{
    public class AccountsController : Controller
    {
        IApplicationBusiness _business;

        public AccountsController(IApplicationBusiness business)
        {
            _business = business;
        }

        [AppAuthorizeRoutingAttribute]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _business.UserLogin(model.UserName, model.UserPassword);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, ((UserType)user.UserType).ToString());
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    if ((int)UserType.Admin == user.UserType)
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", DataCommon.InvalidLogin);
                return View(model);
            }

            ModelState.AddModelError("", DataCommon.InvalidLogin);
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [AppAuthorizeRoutingAttribute]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_business.ValidateExistUser(model.UserName))
                {
                    ModelState.AddModelError("", DataCommon.ExistUser);
                    return View(model); ;
                }

                var user = _business.UserSignUp(model.UserName, model.UserPassword, (int)model.UserType);

                if (user != null)
                {
                    // Auto login after signing up user success
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, ((UserType)user.UserType).ToString());
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    if ((int)UserType.Admin == user.UserType)
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", DataCommon.InvalidSignup);
                return View(model);
            }

            ModelState.AddModelError("", DataCommon.InvalidSignup);
            return View(model);
        }
    }
}