﻿using System.Collections.Generic;
using FreeChat.Core.Models;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface IUsers
    {
        IEnumerable<ApplicationUser> GetRegisteredUsers();

        ApplicationUser GetUser(string id);

        long CountRegisteredUsers();

        bool UpdateUserStatus(bool status, string userId);

        bool IsAdmin(string userId);


    }
}