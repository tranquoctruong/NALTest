using AuthenticationBusiness.UserBusiness;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AuthenticationWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IApplicationBusiness, ApplicationBusiness>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}