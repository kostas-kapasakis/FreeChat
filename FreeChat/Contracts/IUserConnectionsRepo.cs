using FreeChat.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Contracts
{
    public interface IUserConnectionsRepo
    {
        bool AddUserConnection(long connectionId, int userId);
        bool RemoveUserConnection(long connectionId);
        IEnumerable<UserConnections> GetUserConnectionsIdsByUserId(long id);
        bool RemoveUserConnections(long id);
    }
}
