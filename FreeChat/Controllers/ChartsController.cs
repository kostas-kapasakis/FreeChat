using System.Web.Mvc;

namespace FreeChat.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ChartsController : Controller
    {
        // GET: Charts
        public ActionResult Charts()
        {
            return View();
        }
    }
}