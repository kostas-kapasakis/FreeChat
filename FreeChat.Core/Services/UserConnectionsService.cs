using System.Collections.Generic;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Services
{
    public class UserConnectionsService : IUserConnectionsService
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


        public IEnumerable<UserConnection> GetUserConnectionsIdsByUserId(long id)
            => _userConnectionsRepo.GetUserConnectionsIdsByUserId(id);

        public bool RemoveUserConnections(long id)
            => _userConnectionsRepo.RemoveUserConnections(id);



    }
}