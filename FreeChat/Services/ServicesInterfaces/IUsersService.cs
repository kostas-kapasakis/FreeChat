using FreeChat.Models;
using FreeChat.Models.DTO;
using System.Collections.Generic;

namespace FreeChat.Services.ServicesInterfaces
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
