using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using FreeChat.Models;
using FreeChat.Services.ServicesInterfaces;

namespace FreeChat.Controllers.API
{
    public class Email : ApiController
    {
        private readonly IEmailService _service;

        public Email(IEmailService service)
        {
            _service = service;
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> SendEmail(EmailFormModel emailFormModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _service.EmailSender(emailFormModel);

            if (result > 0)
                return Ok();

            return BadRequest();
        }
    }
}