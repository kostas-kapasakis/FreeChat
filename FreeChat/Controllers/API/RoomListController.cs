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


        [HttpGet]
        //[Authorize(Roles = "Administrator")]
        public IHttpActionResult GetTopicsFull()
        {
            var topics = _service.GetTopicsFull();

            return Ok(topics);
        }


        [HttpPost]
        public IHttpActionResult ChangeTopicStatus(long id, bool status)
        {
            return Ok(_service.ChangeTopicStatus(id, status));
        }


        [HttpDelete]
        public IHttpActionResult DeleteTopic(long Id)
            => Ok(_service.DeleteTopicById(Id));





    }
}
