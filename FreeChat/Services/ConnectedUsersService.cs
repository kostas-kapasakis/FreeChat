using FreeChat.Models;
using FreeChat.Repositories.Interfaces;
using System.Collections.Generic;
using FreeChat.Services.ServicesInterfaces;

namespace FreeChat.Services
{
    public class ConnectedUsersService : IConnectedUsersService
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