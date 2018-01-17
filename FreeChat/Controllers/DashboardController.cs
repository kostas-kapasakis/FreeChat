using FreeChat.Models;
using System.Web.Mvc;

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
    }
}