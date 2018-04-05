using System.Web.Mvc;
using FreeChat.Core.Models;

namespace FreeChat.Controllers
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