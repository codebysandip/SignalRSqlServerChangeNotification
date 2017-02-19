using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using DemoCRM.Data.Abstract;
using DemoCRM.Models.Campaign;
using System.Linq;
using System.Data.Entity;

namespace DemoCRM.Data.Concrete
{
    public class CampaignRepositry : ICampaignRepositry
    {
        /// <summary>
        /// Get all compaign data
        /// </summary>
        /// <returns></returns>
        public async Task<List<Campaign>> Get(int take = 10, int skip = 0)
        {
            using (CRMDbContext context = new CRMDbContext())
            {
                return await context.Campaigns.OrderByDescending(x => x.ID).Skip(skip).Take(take).ToListAsync();
            }
        }

        /// <summary>
        /// Get Count of Total Rows of Campaign
        /// </summary>
        /// <returns></returns>
        public async Task<int> TotalRecords()
        {
            using (CRMDbContext context = new CRMDbContext())
            {
                return await context.Campaigns.CountAsync();
            }
        }

        /// <summary>
        /// Get Campaign Detail
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<Campaign> Get(int ID)
        {
            using (CRMDbContext context = new CRMDbContext())
            {
                return await context.Campaigns.FirstAsync(compaign => compaign.ID == ID);
            }
        }

        /// <summary>
        /// New Campaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Add(Campaign model)
        {
            using (CRMDbContext context = new CRMDbContext())
            {
                context.Campaigns.Add(model);
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
        }

        /// <summary>
        /// Delete Campaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Campaign model)
        {
            using (CRMDbContext context = new CRMDbContext())
            {
                context.Entry(model).State = EntityState.Deleted;
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
        }


        /// <summary>
        /// Update Compaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(Campaign model)
        {
            using (CRMDbContext context = new CRMDbContext())
            {
                context.Entry(model).State = EntityState.Modified;
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
        }
    }
}
