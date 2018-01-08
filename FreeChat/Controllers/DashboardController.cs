using System.Web.Mvc;

namespace FreeChat.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult AdminDashboard()
        {
            return View();
        }
    }
}