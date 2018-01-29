using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeChat.Controllers
{
    public class ChatEngineController : Controller
    {
        
        public ActionResult Chatengine()
        {
            return View("Chatengine");
        }
    }
}