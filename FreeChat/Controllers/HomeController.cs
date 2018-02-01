﻿using FreeChat.Models.ViewModels;
using FreeChat.Services.ServicesInterfaces;
using System.Web.Mvc;

namespace FreeChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicsService _topicsService;

        public HomeController(ITopicsService topicsService)
        {
            _topicsService = topicsService;
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MainCategories()
        {
            var mainCategories = _topicsService.GetMainCategories();
            return View("MainCategories", new MainCategoriesViewModel
            {
                MainCategories = mainCategories
            });
        }

        public ActionResult AllChatRooms()
        {
            return View();
        }
    }
}