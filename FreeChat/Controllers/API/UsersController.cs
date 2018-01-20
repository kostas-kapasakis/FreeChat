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

        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetRegisteredUsers()
        {

            var users = _service.GetRegisteredUsers();

            var userdto = users.ToList().Select(Mapper.Map<ApplicationUser, UserDto>);

            return Ok(userdto.ToArray());
        }

        [HttpGet]
        public IHttpActionResult GetCountOfRegisteredUsers()
        {
            return Ok(_service.CountRegisteredUsers());
        }

    }
}
