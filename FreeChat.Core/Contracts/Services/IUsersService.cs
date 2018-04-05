using System.Collections.Generic;
using FreeChat.Core.Models;
using FreeChat.Core.Models.DTO;

namespace FreeChat.Core.Contracts.Services
{
    public interface IUsersService
    {
        UserDto GetUser(string id);
        long CountRegisteredUsers();
        IEnumerable<ApplicationUser> GetRegisteredUsers();
        bool UpdateUserStatus(bool status, string userId);
        bool IsAdmin(string userId);
    }
}
