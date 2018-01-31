using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeChat.Controllers
{
    public class UsersAreaController : Controller
    {
        // GET: UsersArea
        public ActionResult MyRooms()
        {
            return View();
        }
    }
}