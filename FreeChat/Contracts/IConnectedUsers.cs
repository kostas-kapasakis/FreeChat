using FreeChat.Models.Identity;
using System.Collections.Generic;

namespace FreeChat.Contracts
{
    public interface IConnectedUsers
    {
        IEnumerable<ApplicationUser> GetConnectedUsers();
        long CountConnectedUsers();

    }
}
