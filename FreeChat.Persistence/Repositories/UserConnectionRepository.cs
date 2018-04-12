using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Models.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FreeChat.Persistence.Repositories
{
    public class UserConnectionRepository : GenericRepository<UserConnection>, IUserConnectionRepository
    {

        public UserConnectionRepository(FreeChatContext context)
            : base(context)
        {
        }

        public bool AddUserConnection(long connectionId, int userId)
        {

            var user = FreeChatContext.Users.FirstOrDefault(x => x.Id == userId.ToString());

            if (user == null)
                return false;

            var connection = new UserConnection
            {
                ConnectedUserId = connectionId,
                User = user
            };
            FreeChatContext.UserConnections.Add(connection);
            FreeChatContext.SaveChanges();

            return true;
        }

        public bool RemoveUserConnection(long connectionId)
        {
            var listOfConnections = FreeChatContext.UserConnections.Where(x => x.User.Id == connectionId.ToString());

            if (!listOfConnections.Any())
                return false;

            foreach (var connection in listOfConnections)
            {
                FreeChatContext.Entry(connection).State = EntityState.Deleted;
            }

            FreeChatContext.SaveChanges();

            return true;
        }


        public IEnumerable<UserConnection> GetUserConnectionsIdsByUserId(long id)
        {
            var listOfConnections = FreeChatContext.UserConnections.Where(x => x.User.Id == id.ToString());
            if (!listOfConnections.Any())
                return new List<UserConnection>();

            return listOfConnections;

        }

        public bool RemoveAllUserConnections(long connectionId)
        {
            throw new System.NotImplementedException();
        }

        public FreeChatContext FreeChatContext => Context as FreeChatContext;
    }
}