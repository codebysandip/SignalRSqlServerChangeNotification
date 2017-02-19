using System.Web.Mvc;
using Microsoft.Practices.Unity;
using DemoCRM.Data.Abstract;
using DemoCRM.Data.Concrete;
using System.Web.Http;

namespace DemoCRM.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<ICampaignRepositry, CampaignRepositry>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}