using CUSTOMER.SERVICES.IServices;
using CUSTOMER.SERVICES.Services;
using DATA.ACCESS.LAYER;
using DATA.ACCESS.LAYER.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CUSTOMER.BACKEND
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IUserService, UserService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}