using FreeChat.Services.ServicesInterfaces;
using Microsoft.AspNet.SignalR.Messaging;
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


        public ActionResult ChatStart(Topic roomTopic)
        {
            var currentUser = System.Web.HttpContext.Current.User.Identity.Name;
            var
            return View("Chatengine");
        }
    }
}