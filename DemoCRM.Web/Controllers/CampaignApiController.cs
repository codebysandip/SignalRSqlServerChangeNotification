using DemoCRM.Data.Abstract;
using DemoCRM.Models.Campaign;
using DemoCRM.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DemoCRM.Web.Controllers
{
    public class CampaignApiController : ApiController
    {
        private ICampaignRepositry _repo;
        public CampaignApiController(ICampaignRepositry repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// Get all compaign
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            int skip = int.Parse(HttpContext.Current.Request.QueryString["start"]);
            int take = int.Parse(HttpContext.Current.Request.QueryString["length"]);
            var totalRecords = _repo.TotalRecords();
            return Ok(new DataTableRespnse<List<Campaign>>
            {
                data = await _repo.Get(take, skip),
                draw = int.Parse(HttpContext.Current.Request.QueryString["draw"]),
                recordsTotal = await totalRecords,
                recordsFiltered = await totalRecords
            });
        }
    }
}
