using FreeChat.Models;

namespace FreeChat.Services.ServicesInterfaces
{
    public interface IEmailService
    {
        int EmailSender(EmailFormModel model);
    }
}
