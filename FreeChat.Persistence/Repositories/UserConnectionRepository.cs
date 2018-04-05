using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Persistence.Repositories
{
    public class UserConnectionRepository :GenericRepository<UserConnections>, IUserConnectionRepository
    {
        private readonly FreeChatContext _freeChatContext;

        public UserConnectionRepository(FreeChatContext context)
            :base(context)
        {
            _freeChatContext = context;
        }


        public bool AddUserConnection(long connectionId, int userId)
        {

            var user = _freeChatContext.Users.FirstOrDefault(x => x.Id == userId.ToString());

            if (user == null)
                return false;

            var connection = new UserConnections
            {
                ConnectionId = connectionId,
                Username = user.UserName,
                User = user
            };
            _freeChatContext.UserConnections.Add(connection);
            _freeChatContext.SaveChanges();

            return true;

        }

        public bool RemoveUserConnection(long connectionId)
        {
            var connection = _freeChatContext.UserConnections.FirstOrDefault(x => x.ConnectionId == connectionId);

            if (connection == null)
                return false;

            _freeChatContext.Entry(connection).State = EntityState.Deleted;
            _freeChatContext.SaveChanges();

            return true;

        }

        public IEnumerable<UserConnections> GetUserConnectionsIdsByUserId(long id)
        {
            var listOfConnections = _freeChatContext.UserConnections.Where(x => x.User.Id == id.ToString());
            if (!listOfConnections.Any())
                return new List<UserConnections>();

            return listOfConnections;

        }

        public bool RemoveUserConnections(long id)
        {
            var listOfConnections = _freeChatContext.UserConnections.Where(x => x.User.Id == id.ToString());
            if (!listOfConnections.Any())
                return false;

            foreach (var connection in listOfConnections)
            {
                _freeChatContext.Entry(connection).State = EntityState.Deleted;
            }
            _freeChatContext.SaveChanges();

            return true;
        }
    }
}