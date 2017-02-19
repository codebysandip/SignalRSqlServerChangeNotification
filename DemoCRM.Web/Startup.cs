using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoCRM.Web.Startup))]
namespace DemoCRM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }

    }
}
