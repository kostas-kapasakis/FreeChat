using FreeChat.Models;
using FreeChat.Repositories.Interfaces;
using FreeChat.Services.ServicesInterfaces;
using System.Collections.Generic;

namespace FreeChat.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsers _userRepo;

        public UsersService(IUsers userRepo)
        {
            _userRepo = userRepo;
        }

        public long CountRegisteredUsers()
            => _userRepo.CountRegisteredUsers();

        public IEnumerable<ApplicationUser> GetRegisteredUsers()
        {
            return _userRepo.GetRegisteredUsers();

        }

        public bool UpdateUserStatus(bool status, string userId)
        {
            return _userRepo.UpdateUserStatus(status, userId);
        }

        public bool IsAdmin(string userId)
        {
            return _userRepo.IsAdmin(userId);
        }

    }
}