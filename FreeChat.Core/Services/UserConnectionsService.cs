using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Contracts.UOW;
using FreeChat.Core.Models.Domain;
using System.Collections.Generic;


namespace FreeChat.Core.Services
{
    public class UserConnectionsService : IUserConnectionsService
    {
        private readonly IUserConnectionsUnitOfWork _unitOfWork;

        public UserConnectionsService(IUserConnectionsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddUserConnection(long connectionId, int userId)
        {
            var result = _unitOfWork.UserConnection.AddUserConnection(connectionId, userId);
            _unitOfWork.Complete();
            return result;
        }




        public bool RemoveUserConnection(long connectionId)
        {
            var result = _unitOfWork.UserConnection.RemoveUserConnection(connectionId);
            _unitOfWork.Complete();
            return result;
        }





        public IEnumerable<UserConnection> GetUserConnectionsIdsByUserId(long id)
            => _unitOfWork.UserConnection.GetUserConnectionsIdsByUserId(id);

        public bool RemoveUserConnections(long id)
        {
            var result = _unitOfWork.UserConnection.RemoveUserConnection(id);
            _unitOfWork.Complete();
            return result;
        }





    }
}