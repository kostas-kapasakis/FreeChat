using FreeChat.Core.Models;
using System.Web.Mvc;

namespace FreeChat.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Rooms()
        {

            return View();
        }
    }
}