using System.Collections.Generic;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Services
{
    public class UserConnectionsService : IUserConnectionsService
    {
        private readonly IUserConnectionRepository _userConnectionRepository;

        public UserConnectionsService(IUserConnectionRepository userConnectionRepository)
        {
            _userConnectionRepository = userConnectionRepository;
        }

        public bool AddUserConnection(long connectionId, int userId)
            => _userConnectionRepository.AddUserConnection(connectionId, userId);


        public bool RemoveUserConnection(long connectionId)
            => _userConnectionRepository.RemoveUserConnection(connectionId);


        public IEnumerable<UserConnections> GetUserConnectionsIdsByUserId(long id)
            => _userConnectionRepository.GetUserConnectionsIdsByUserId(id);

        public bool RemoveUserConnections(long id)
            => _userConnectionRepository.RemoveUserConnections(id);



    }
}