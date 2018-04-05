using FreeChat.Core.Models;

namespace FreeChat.Core.Contracts.Services
{
    public interface IEmailService
    {
        int EmailSender(EmailFormModel model);
    }
}
