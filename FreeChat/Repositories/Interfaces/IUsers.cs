using FreeChat.Models;
using System.Collections.Generic;

namespace FreeChat.Repositories.Interfaces
{
    public interface IUsers
    {
        IEnumerable<ApplicationUser> GetRegisteredUsers();
        long CountRegisteredUsers();

        bool UpdateUserStatus(bool status, string userId);




    }
}
