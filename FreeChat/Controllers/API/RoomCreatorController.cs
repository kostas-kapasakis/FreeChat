using FreeChat.Models.DTO;
using FreeChat.Services;
using System.Web.Http;

namespace FreeChat.Controllers.API
{
    public class RoomCreatorController : ApiController
    {
        private readonly TopicsService _service;

        public RoomCreatorController(TopicsService service)
        {
            _service = service;
        }

        [HttpPost]
        public IHttpActionResult CreateRoom(CreateChatRoomDto chatRoom)
        {
            return Ok(_service.AddTopic(chatRoom));
        }


    }
}
