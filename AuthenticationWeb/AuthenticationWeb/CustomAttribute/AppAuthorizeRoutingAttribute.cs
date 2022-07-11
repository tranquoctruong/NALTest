using AuthenticationWeb.Common;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationWeb.CustomAttribute
{
    public class AppAuthorizeRoutingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var islogin = HttpContext.Current.User.Identity.IsAuthenticated;

            if (islogin)
            {
                var isAdmin = HttpContext.Current.User.IsInRole(UserType.Admin.ToString());

                var request = HttpContext.Current.Request;
                string controller = request.RequestContext.RouteData.Values["controller"].ToString();
                string action = request.RequestContext.RouteData.Values["action"].ToString();

                if(controller == "Accounts")
                {
                    //If already login then redirect to app, not login again
                    filterContext.Result = isAdmin ? new RedirectResult("/Admin/Index")
                        : new RedirectResult("/Home/Index");
                }
                else
                {
                    //Allow user access function by role
                    if(isAdmin && controller == "Home") filterContext.Result = new RedirectResult("/Admin/Index");
                    if(!isAdmin && controller == "Admin") filterContext.Result = new RedirectResult("/Home/Index");                
                }
            }
        }
    }
}