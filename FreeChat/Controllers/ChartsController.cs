using FreeChat.Models;
using System.Web.Mvc;

namespace FreeChat.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ChartsController : Controller
    {
        // GET: Charts
        public ActionResult Charts()
        {
            return View();
        }
    }
}