using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

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