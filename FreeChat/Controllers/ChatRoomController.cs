using System.Web.Mvc;

namespace FreeChat.Controllers
{
    public class ChatRoomController : Controller
    {
        // GET: ChatRoom
        public ActionResult Create()
        {
            return View();
        }
    }
}