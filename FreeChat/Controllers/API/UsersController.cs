using AutoMapper;
using FreeChat.Models;
using FreeChat.Models.DTO;
using FreeChat.Services.ServicesInterfaces;
using System.Linq;
using System.Web.Http;

namespace FreeChat.Controllers.API
{
    public class UsersController : ApiController
    {

        private readonly IUsersService _usersService;
        private readonly ITopicsService _topicsService;

        public UsersController(IUsersService usersService, ITopicsService topicsService)
        {
            _usersService = usersService;
            _topicsService = topicsService;
        }

        [HttpGet]
        public IHttpActionResult GetRegisteredUsers()
        {

            var users = _usersService.GetRegisteredUsers();

            var userdto = users.ToList().Select(Mapper.Map<ApplicationUser, UserDto>);

            return Ok(userdto);
        }

        [HttpGet]
        public IHttpActionResult GetCountOfRegisteredUsers()
        {
            return Ok(_usersService.CountRegisteredUsers());
        }

        [HttpPost]
        public bool UpdateUserActiveStatus(bool status, string userId)
        {
            return _usersService.UpdateUserStatus(status, userId);
        }

        [HttpGet]

        public IHttpActionResult GetRoomsLeftForUser(string userId)
        {
            var roomsLeft = _topicsService.RoomsRemainingForUser(userId);

            return Ok(roomsLeft);
        }

    }
}
