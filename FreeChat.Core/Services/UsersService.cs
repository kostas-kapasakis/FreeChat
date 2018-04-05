using System.Collections.Generic;
using AutoMapper;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models;
using FreeChat.Core.Models.DTO;

namespace FreeChat.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepositoryRepo;

        public UsersService(IUserRepository userRepositoryRepo)
        {
            _userRepositoryRepo = userRepositoryRepo;
        }

        public UserDto GetUser(string id)
        {
            return Mapper.Map<ApplicationUser, UserDto>(_userRepositoryRepo.GetUser(id));
        }

        public long CountRegisteredUsers()
            => _userRepositoryRepo.CountRegisteredUsers();

        public IEnumerable<ApplicationUser> GetRegisteredUsers()
        {
            return _userRepositoryRepo.GetRegisteredUsers();

        }

        public bool UpdateUserStatus(bool status, string userId)
        {
            return _userRepositoryRepo.UpdateUserStatus(status, userId);
        }

        public bool IsAdmin(string userId)
        {
            return _userRepositoryRepo.IsAdmin(userId);
        }

    }
}