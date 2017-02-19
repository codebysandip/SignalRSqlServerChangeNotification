using DemoCRM.Models.Campaign;
using System.Data.Entity;

namespace DemoCRM.Data
{
    public class CRMDbContext: DbContext
    {
        public CRMDbContext(): base("SqlServerConnection") { }

        public DbSet<Campaign> Campaigns { get; set; }

    }
}