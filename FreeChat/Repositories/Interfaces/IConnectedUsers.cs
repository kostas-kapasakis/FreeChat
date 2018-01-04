using System.Collections.Generic;
using FreeChat.Models;

namespace FreeChat.Repositories.Interfaces
{
    public interface IConnectedUsers
    {
        IEnumerable<ApplicationUser> GetConnectedUsers();
        long CountConnectedUsers();

    }
}
