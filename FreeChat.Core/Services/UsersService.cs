
using AutoMapper;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Contracts.UOW;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using System.Collections.Generic;

namespace FreeChat.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersUnitOfWork _unitOfWork;

        public UsersService(IUsersUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserDto GetUser(string id)
            => Mapper.Map<User, UserDto>(_unitOfWork.User.Get(id));

        public long CountRegisteredUsers()
            => _unitOfWork.User.CountRegisteredUsers();

        public IEnumerable<User> GetRegisteredUsers()
            => _unitOfWork.User.GetAll();

        public bool UpdateUserStatus(bool status, string userId)
        {
            var result = _unitOfWork.User.UpdateUserStatus(status, userId);
            _unitOfWork.Complete();
            return result;
        }

        public bool IsAdmin(string userId)
            => _unitOfWork.User.IsAdmin(userId);


    }
}