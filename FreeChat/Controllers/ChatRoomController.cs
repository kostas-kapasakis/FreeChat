using AutoMapper;
using FreeChat.Models.Domain;
using FreeChat.Models.DTO;
using FreeChat.Models.ViewModels;
using FreeChat.Services.ServicesInterfaces;
using System.Collections.Generic;
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

            return View("Create", new CreateRoomViewModel
            {
                MainCategories = Mapper.Map<IEnumerable<MainCategoriesDto>, IEnumerable<MainCategories>>(mainCategories)
            });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TopicsDto chatRoom)
        {
            var verdict = _service.AddTopic(chatRoom);

            return RedirectToAction("MainCategories", "Home");

        }
    }
}