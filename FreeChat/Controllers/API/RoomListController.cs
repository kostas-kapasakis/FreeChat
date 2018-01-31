using FreeChat.Services.ServicesInterfaces;
using System.Web.Http;

namespace FreeChat.Controllers.API
{
    public class RoomListController : ApiController
    {
        private readonly ITopicsService _service;

        public RoomListController(ITopicsService service)
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
        public IHttpActionResult GetRoomsForSpecificGenre(long id)
        {
            var genreRooms = _service.GetActiveTopicsByGenreId(id);

            if (genreRooms == null)
                return BadRequest();

            return Ok(genreRooms);
        }


        [HttpGet]
        public IHttpActionResult GetMainCategories()
            => Ok(_service.GetMainCategories());

        [HttpGet]
        public IHttpActionResult GetUserTopics(string id)
            => Ok(_service.GetUserTopics(id));




    }
}
