using FreeChat.Services.ServicesInterfaces;
using System.Web.Http;

namespace FreeChat.Controllers.API
{
    public class RoomListsController : ApiController
    {
        private readonly ITopicsService _service;

        public RoomListsController(ITopicsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetAllRooms()
        {
            var activeRooms = _service.GetActiveTopics();

            if (activeRooms == null)
                return NotFound();

            return Ok(activeRooms);
        }

        [HttpGet]
        public IHttpActionResult GetRoomsForSpecificGenre(string genre)
        {
            var genreRooms = _service.GetActiveTopicsByGenre(genre);

            if (genreRooms == null)
                return BadRequest();

            return Ok(genreRooms);
        }



    }
}
