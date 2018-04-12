﻿using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        long CountRegisteredUsers();

        bool UpdateUserStatus(bool status, string userId);

        bool IsAdmin(string userId);


    }
}
