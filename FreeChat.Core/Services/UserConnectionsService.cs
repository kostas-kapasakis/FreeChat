using System.Collections.Generic;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Services
{
    public class UserConnectionsService : IUserConnectionsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserConnectionsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddUserConnection(long connectionId, int userId)
        {
            var result =   _unitOfWork.UserConnection.AddUserConnection(connectionId, userId);
            _unitOfWork.Complete();
            return result;
        }




        public bool RemoveUserConnection(long connectionId)
        {
            var result =  _unitOfWork.UserConnection.RemoveUserConnection(connectionId);
            _unitOfWork.Complete();
            return result;
        }

      


        public IEnumerable<UserConnections> GetUserConnectionsIdsByUserId(long id)
            => _unitOfWork.UserConnection.GetUserConnectionsIdsByUserId(id);

        public bool RemoveUserConnections(long id)
        {
            var result = _unitOfWork.UserConnection.RemoveUserConnections(id);
            _unitOfWork.Complete();
            return result;
        }

       



    }
}