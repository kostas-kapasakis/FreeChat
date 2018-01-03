using FreeChat.Contracts;
using FreeChat.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Services
{
    public class UserConnectionsService
    {
        private readonly IUserConnectionsRepo _userConnectionsRepo;

        public UserConnectionsService(IUserConnectionsRepo userConnectionsRepo)
        {
            _userConnectionsRepo = userConnectionsRepo;
        }

        public bool AddUserConnection(long connectionId, int userId)
            => _userConnectionsRepo.AddUserConnection(connectionId, userId);

        public bool RemoveUserConnection(long connectionId)
            => _userConnectionsRepo.RemoveUserConnection(connectionId);

        public IEnumerable<UserConnections> GetUserConnectionsIdsByUserId(long id)
            => _userConnectionsRepo.GetUserConnectionsIdsByUserId(id);

        public bool RemoveUserConnections(long id)
            => _userConnectionsRepo.RemoveUserConnections(id);



    }
}