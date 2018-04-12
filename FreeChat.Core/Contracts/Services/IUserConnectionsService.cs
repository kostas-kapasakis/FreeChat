using FreeChat.Core.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Core.Contracts.Services
{
    public interface IUserConnectionsService
    {
        bool AddUserConnection(long connectionId, int userId);

        bool RemoveUserConnection(long connectionId);

        IEnumerable<UserConnection> GetUserConnectionsIdsByUserId(long id);

        bool RemoveUserConnections(long id);

    }
}
