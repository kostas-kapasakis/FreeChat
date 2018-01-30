using FreeChat.Services.ServicesInterfaces;
using System.Web.Mvc;

namespace FreeChat.Controllers
{
    public class ChatEngineController : Controller
    {

        private readonly ITopicsService _service;

        public ChatEngineController(ITopicsService service)
        {
            _service = service;
        }


        public ActionResult ChatStart()
        {
            return View("Chatengine");
        }
    }
}