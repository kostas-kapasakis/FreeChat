using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Persistence.Repositories
{
    public class UserConnectionRepository :GenericRepository<UserConnections>, IUserConnectionRepository
    {

        public UserConnectionRepository(FreeChatContext context)
            :base(context)
        {
        }

        public bool AddUserConnection(long connectionId, int userId)
        {

            var user = FreeChatContext.Users.FirstOrDefault(x => x.Id == userId.ToString());

            if (user == null)
                return false;

            var connection = new UserConnections
            {
                ConnectionId = connectionId,
                Username = user.UserName,
                User = user
            };
            FreeChatContext.UserConnections.Add(connection);
            FreeChatContext.SaveChanges();

            return true;
        }

        public bool RemoveUserConnection(long connectionId)
        {
            var connection = FreeChatContext.UserConnections.FirstOrDefault(x => x.ConnectionId == connectionId);

            if (connection == null)
                return false;

            FreeChatContext.Entry(connection).State = EntityState.Deleted;
            FreeChatContext.SaveChanges();

            return true;
        }

        public IEnumerable<UserConnections> GetUserConnectionsIdsByUserId(long id)
        {
            var listOfConnections = FreeChatContext.UserConnections.Where(x => x.User.Id == id.ToString());
            if (!listOfConnections.Any())
                return new List<UserConnections>();

            return listOfConnections;

        }

        public bool RemoveUserConnections(long id)
        {
            var listOfConnections = FreeChatContext.UserConnections.Where(x => x.User.Id == id.ToString());
            if (!listOfConnections.Any())
                return false;

            foreach (var connection in listOfConnections)
            {
                FreeChatContext.Entry(connection).State = EntityState.Deleted;
            }
            FreeChatContext.SaveChanges();

            return true;
        }

        public FreeChatContext FreeChatContext => Context as FreeChatContext;
    }
}