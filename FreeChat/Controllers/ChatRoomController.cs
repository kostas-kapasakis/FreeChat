using AutoMapper;
using FreeChat.Models.Domain;
using FreeChat.Models.DTO;
using FreeChat.Models.ViewModels;
using FreeChat.Services.ServicesInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FreeChat.Controllers
{
    public class ChatRoomController : Controller
    {
        private readonly ITopicsService _service;

        public ChatRoomController(ITopicsService service)
        {
            _service = service;
        }


        public ActionResult Create()
        {
            var mainCategories = _service.GetMainCategories();

            return View("Create", new NewChatRoomViewModel
            {
                MainCategories = Mapper.Map<IEnumerable<MainCategoriesDto>, IEnumerable<MainCategories>>(mainCategories)
            });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoom(NewChatRoomViewModel chatRoom)
        {
            var mainCategories = _service.GetMainCategories();

            if (!ModelState.IsValid)
            {

                return View("Create", new NewChatRoomViewModel
                {
                    MainCategories = Mapper.Map<IEnumerable<MainCategoriesDto>, IEnumerable<MainCategories>>(mainCategories)
                });
            }

            var genre = mainCategories.Where(x => x.Id == chatRoom.Topic.MainCategoryId);
            var topic = new TopicsDto
            {
                Name = chatRoom.Topic.Name,
                Description = chatRoom.Topic.Description,
                MainCategoryId = chatRoom.Topic.MainCategoryId,
                Genre = genre.Select(room => room.Name).SingleOrDefault(),
                Active = true,
            };

            return _service.AddTopic(topic)
                ? RedirectToAction("AllChatRooms", "Home")
                : RedirectToAction("CustomError", "CustomError");




        }
    }
}