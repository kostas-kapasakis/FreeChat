using System.Collections.Generic;
using FreeChat.Models;

namespace FreeChat.Services.ServicesInterfaces
{
    public interface IConnectedUsersService
    {
        long CountConnectedUsers();
        IEnumerable<ApplicationUser> GetConnectedUsers();

    }
}
