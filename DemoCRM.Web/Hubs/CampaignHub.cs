using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Configuration;

namespace DemoCRM.Web.Hubs
{
    public class CampaignHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ToString();

        [HubMethodName("sendCampaigns")]
        public static void SendCampaigns()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CampaignHub>();
            context.Clients.All.updateCampaign();
        }
    }
}