using System.Collections.Generic;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface IUserConnectionRepository:IGenericRepository<UserConnections>
    {
        bool AddUserConnection(long connectionId, int userId);
        bool RemoveUserConnection(long connectionId);
        IEnumerable<UserConnections> GetUserConnectionsIdsByUserId(long id);
        bool RemoveUserConnections(long id);
    }
}
