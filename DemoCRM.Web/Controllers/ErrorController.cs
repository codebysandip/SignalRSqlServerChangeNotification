using System.Web.Mvc;

namespace DemoCRM.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServerError()
        {
            return View();
        }
    }
}
