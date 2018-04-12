using FreeChat.Core.Models;
using System.Web.Mvc;

namespace FreeChat.Web.Controllers
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