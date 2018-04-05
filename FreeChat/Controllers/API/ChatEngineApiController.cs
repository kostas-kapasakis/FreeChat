using System.Web.Http;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.Enums;

namespace FreeChat.Controllers.API
{
    public class ChatEngineApiController : ApiController
    {
        private readonly ITopicsService _service;

        public ChatEngineApiController(ITopicsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult ChatEngine(long roomId)
        {
            var room = _service.GetTopicById(roomId);
            var verdict = _service.ValidateRoom(room.Id);


            if (verdict != TopicValidationPriorEnteringEnum.RoomExistsAndisAvailable)
            {
                return BadRequest("Not available room");
            }

            return Ok(room);
        }

    }
}
