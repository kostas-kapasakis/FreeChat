using System.Web.Mvc;

namespace FreeChat.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ChartsController : Controller
    {
        // GET: Charts
        public ActionResult Charts()
        {
            return View();
        }
    }
}