using System.Web.Mvc;

namespace FreeChat.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult AdminDashboard()
        {
            return View();
        }
    }
}