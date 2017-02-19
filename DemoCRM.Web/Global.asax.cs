using DemoCRM.Models.Campaign;
using DemoCRM.Web.Hubs;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TableDependency.SqlClient;

namespace DemoCRM.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        SqlTableDependency<Campaign> dependency = new SqlTableDependency<Campaign>(ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString, "DevTest");

        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            tabledependency();
        }

        private void tabledependency()
        {
            dependency.OnChanged += Dependency_OnChanged;
            dependency.Start();
        }

        private void Dependency_OnChanged(object sender, TableDependency.EventArgs.RecordChangedEventArgs<Campaign> e)
        {
            CampaignHub.SendCampaigns();
        }

        protected void Application_End()
        {
            //Stop SQL table dependency
            dependency.Stop();
        }
    }
}
