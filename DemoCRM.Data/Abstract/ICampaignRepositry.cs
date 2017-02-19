using DemoCRM.Models.Campaign;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoCRM.Data.Abstract
{
    public interface ICampaignRepositry
    {
        /// <summary>
        /// Get all Campaign
        /// </summary>
        /// <returns></returns>
        Task<List<Campaign>> Get(int take = 10, int skip = 0);

        /// <summary>
        /// Get Campaign Detail
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<Campaign> Get(int ID);

        /// <summary>
        /// Get total rows of Compaign
        /// </summary>
        /// <returns></returns>
        Task<int> TotalRecords();

        /// <summary>
        /// Add Campaign
        /// </summary>
        /// <returns></returns>
        Task<bool> Add(Campaign model);

        /// <summary>
        /// Update Compaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Update(Campaign model);

        /// <summary>
        /// Delete Compaign
        /// </summary>
        /// <returns></returns>
        Task<bool> Delete(Campaign model);

    }
}
