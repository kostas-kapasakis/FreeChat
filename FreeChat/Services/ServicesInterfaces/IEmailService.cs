using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeChat.Models;

namespace FreeChat.Services.ServicesInterfaces
{
   public interface IEmailService
   {
       Task<int> EmailSender(EmailFormModel model);
   }
}
