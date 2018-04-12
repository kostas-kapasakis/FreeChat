using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using System.Collections.Generic;

namespace FreeChat.Core.Contracts.Services
{
    public interface IUsersService
    {
        UserDto GetUser(string id);

        long CountRegisteredUsers();

        IEnumerable<User> GetRegisteredUsers();

        bool UpdateUserStatus(bool status, string userId);

        bool IsAdmin(string userId);
    }
}
