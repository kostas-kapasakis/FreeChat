using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.DTO;
using System.Web.Http;
using System.Web.Mvc;

namespace FreeChat.Web.Controllers.API
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
