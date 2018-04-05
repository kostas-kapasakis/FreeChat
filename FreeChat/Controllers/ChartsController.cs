using System.Web.Mvc;
using FreeChat.Core.Models;

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