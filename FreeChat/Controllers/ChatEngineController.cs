using System;
using FreeChat.Services.ServicesInterfaces;
using Microsoft.AspNet.SignalR.Messaging;
using System.Web.Mvc;
using Autofac.Core;
using FreeChat.Models.Domain;
using FreeChat.Models.ViewModels;

namespace FreeChat.Controllers
{
    public class ChatEngineController : Controller
    {

        private readonly ITopicsService _service;

        public ChatEngineController(ITopicsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult ChatStart(long? roomid)
        {
            var topic = new Topics();
//            /var currentUser = System.Web.HttpContext.Current.User.Identity.Name;
            var topicId = roomid.GetValueOrDefault();
            if (topicId != 0)
                topic = _service.GetTopicById(topicId);

            
            return View("Chatengine",new ChatEngineViewModel
            {
                Id = topic.Id,
                Name = topic.Name,
                Description = topic.Description,
                Genre = topic.Genre,
                ExpirationDate = topic.DateExpired,
                CreatedDate = topic.DateCreated
            });
        }
    }
}