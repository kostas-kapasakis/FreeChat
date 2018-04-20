using AutoMapper;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using FreeChat.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FreeChat.Web.Controllers
{
    public class ChatRoomController : Controller
    {
        private readonly ITopicsService _topicsService;


        public ChatRoomController(ITopicsService topicsService, IUsersService usersService)
        {
            _topicsService = topicsService;
        }


        public ActionResult Create()
        {

            var user = User.Identity.GetUserId();
            var mainCategories = _topicsService.GetMainCategories();
            var roomsLeft = _topicsService.RoomsRemainingForUser(user);
            var userTopics = _topicsService.GetUserTopics(user);
            var topicsDtos = userTopics as IList<TopicDto> ?? userTopics.ToList();
            var roomsCreated = topicsDtos.Count;

            return View("Create", new NewChatRoomViewModel
            {
                MainCategories = Mapper.Map<IEnumerable<MainCategoryDto>, IEnumerable<MainCategory>>(mainCategories),
                RoomsLeft = roomsLeft,
                RoomsCreated = roomsCreated,
                UserTopics = topicsDtos

            });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoom(NewChatRoomViewModel chatRoom)
        {
            var user = User.Identity.GetUserId();
            var mainCategories = _topicsService.GetMainCategories();

            if (!ModelState.IsValid)
            {
                var userTopics = _topicsService.GetUserTopics(user);
                var topicsDtos = userTopics as IList<TopicDto> ?? userTopics.ToList();
                return View("Create", new NewChatRoomViewModel
                {
                    MainCategories = Mapper.Map<IEnumerable<MainCategoryDto>, IEnumerable<MainCategory>>(mainCategories),
                    UserTopics = topicsDtos
                });
            }

            var genre = mainCategories.Where(x => x.Id == chatRoom.MainCategoryId);
            var topic = new TopicDto
            {
                Name = chatRoom.RoomName,
                Description = chatRoom.Description,
                MainCategoryId = chatRoom.MainCategoryId,
                Genre = genre.Select(room => room.Name).SingleOrDefault(),
                Active = true,
                UserCreatorId = user
            };

            return _topicsService.AddTopic(topic)
                ? RedirectToAction("MyRooms", "UsersArea")
                : RedirectToAction("CustomError", "CustomError");




        }
    }
}