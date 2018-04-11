using AutoMapper;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using System.Collections.Generic;

namespace FreeChat.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsers _userRepo;

        public UsersService(IUsers userRepo)
        {
            _userRepo = userRepo;
        }

        public UserDto GetUser(string id)
        {
            return Mapper.Map<ApplicationUser, UserDto>(_userRepo.GetUser(id));
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