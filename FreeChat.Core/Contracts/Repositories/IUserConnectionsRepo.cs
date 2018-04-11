﻿using System.Collections.Generic;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface IUserConnectionsRepo
    {
        bool AddUserConnection(long connectionId, int userId);
        bool RemoveUserConnection(long connectionId);
        IEnumerable<UserConnection> GetUserConnectionsIdsByUserId(long id);
        bool RemoveUserConnections(long id);
    }
}