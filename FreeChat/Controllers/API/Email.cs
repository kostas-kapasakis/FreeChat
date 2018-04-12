using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models;
using System.Web.Http;
using System.Web.Mvc;

namespace FreeChat.Web.Controllers.API
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
        public IHttpActionResult SendEmail(EmailFormModel emailFormModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = _service.EmailSender(emailFormModel);

            if (result > 0)
                return Ok();

            return BadRequest();
        }
    }
}