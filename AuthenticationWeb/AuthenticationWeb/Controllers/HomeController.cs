using AuthenticationBusiness;
using AuthenticationBusiness.UserBusiness;
using AuthenticationWeb.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationWeb.Controllers
{
    [Authorize]
    [AppAuthorizeRoutingAttribute]
    public class HomeController : Controller
    {
        IApplicationBusiness _business;
        public HomeController(IApplicationBusiness business)
        {
            _business = business;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}