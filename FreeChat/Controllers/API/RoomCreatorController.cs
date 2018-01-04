using FreeChat.Models.DTO;
using FreeChat.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace FreeChat.Controllers.API
{
    public class RoomCreatorController : ApiController
    {
        private readonly TopicsService _service;

        public RoomCreatorController(TopicsService service)
        {
            _service = service;
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public IHttpActionResult CreateRoom(TopicsDto chatRoom)
        {
            return Ok(_service.AddTopic(chatRoom));
        }


    }
}
