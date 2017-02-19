using DemoCRM.Data.Abstract;
using DemoCRM.Models.Campaign;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DemoCRM.Web.Controllers
{
    public class CampaignController : Controller
    {
        private ICampaignRepositry _repo;   
        public CampaignController(ICampaignRepositry repo)
        {
            _repo = repo;
        }
        
        /// <summary>
        /// Campaign home page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        ///// <summary>
        ///// Get all compaign
        ///// </summary>
        ///// <returns></returns>
        //public async Task<ActionResult> Campaigns()
        //{
        //    try
        //    {
        //        int skip = int.Parse(Request.QueryString["start"]);
        //        int take = int.Parse(Request.QueryString["length"]);
        //        return Json(new DataTableRespnse<List<Campaign>> { data = await _repo.Get(take, skip), draw = int.Parse(Request.QueryString["draw"]), recordsTotal = 15, recordsFiltered = 15 }, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (System.Exception ex)
        //    {

        //        throw;
        //    }
        //}

       /// <summary>
       /// Get Campaign details
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        public ActionResult Details(int Id)
        {
            return View(_repo.Get(Id));
        }

        /// <summary>
        /// Add New Compaign
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compaign/Create
        [HttpPost]
        public async Task<ActionResult> Create(Campaign model)
        {
            if (ModelState.IsValid)
            {
                if (await _repo.Add(model))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Data didn't saved. Please try again after some time");
                return View(model);
            }
            ModelState.AddModelError("", "Please fill all required data");
            return View(model);
        }

        /// <summary>
        /// Update existing compaign
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int Id)
        {
            return View(await _repo.Get(Id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Campaign model)
        {
            if (ModelState.IsValid)
            {
                if (await _repo.Update(model))
                {
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError("", "Data didn't saved. Please try again after some time");
                return View(model);
            }
            ModelState.AddModelError("", "Please fill all required data");
            return View(model);
        }

        /// <summary>
        /// Delete compaign
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int Id)
        {
            return View(await _repo.Get(Id));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Campaign model)
        {
            if (await _repo.Delete(model))
            {
                return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}
