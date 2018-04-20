using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.Domain;
using FreeChat.Web.ViewModels;
using System.Web.Mvc;

namespace FreeChat.Web.Controllers
{
    public class ChatEngineController : Controller
    {

        private readonly ITopicsService _service;

        public ChatEngineController(ITopicsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult ChatStart(long? roomid)
        {
            var topic = new Topic();

            var topicId = roomid.GetValueOrDefault();
            if (topicId != 0)
                topic = _service.GetTopic(topicId);


            return View("Chatengine", new ChatEngineViewModel
            {
                Id = topic.Id,
                Name = topic.Name,
                Description = topic.Description,
                Genre = topic.Genre,
                ExpirationDate = topic.DateExpired,
                CreatedDate = topic.DateCreated
            });
        }
    }
}