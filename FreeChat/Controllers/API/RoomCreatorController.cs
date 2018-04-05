using System.Web.Http;
using System.Web.Mvc;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.DTO;

namespace FreeChat.Controllers.API
{
    public class RoomCreatorController : ApiController
    {
        private readonly ITopicsService _service;

        public RoomCreatorController(ITopicsService service)
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
