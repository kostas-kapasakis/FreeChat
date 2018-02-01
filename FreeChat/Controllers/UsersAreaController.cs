using FreeChat.Models.ViewModels;
using FreeChat.Services.ServicesInterfaces;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace FreeChat.Controllers
{
    public class UsersAreaController : Controller
    {
        private readonly ITopicsService _topicsService;

        public UsersAreaController(ITopicsService topicsService)
        {
            _topicsService = topicsService;
        }

        // GET: UsersArea
        public ActionResult MyRooms()
        {
            var userId = User.Identity.GetUserId();
            var userTopics = _topicsService.GetUserTopics(userId);

            return View("MyRooms", new MyRoomsViewModel
            {
                MyTopics = userTopics
            });
        }
    }
}