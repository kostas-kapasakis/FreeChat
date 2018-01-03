using FreeChat.Contracts;
using FreeChat.Models.Identity;
using System.Collections.Generic;

namespace FreeChat.Services
{
    public class ConnectedUsersService
    {
        private readonly IConnectedUsers _connectedUserRepo;

        public ConnectedUsersService(IConnectedUsers connectedUserRepo)
        {
            _connectedUserRepo = connectedUserRepo;
        }

        public long CountConnectedUsers()
            => _connectedUserRepo.CountConnectedUsers();

        public IEnumerable<ApplicationUser> GetConnectedUsers()
            => _connectedUserRepo.GetConnectedUsers();



    }
}