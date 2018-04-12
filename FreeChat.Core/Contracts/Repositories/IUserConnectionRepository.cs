using FreeChat.Core.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface IUserConnectionRepository : IGenericRepository<UserConnection>
    {
        bool AddUserConnection(long connectionId, int userId);

        bool RemoveUserConnection(long connectionId);

        IEnumerable<UserConnection> GetUserConnectionsIdsByUserId(long id);

        bool RemoveAllUserConnections(long connectionId);
    }
}
