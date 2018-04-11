using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Models.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FreeChat.Persistence.Repositories
{
    public class UserConnectionsRepository : IUserConnectionsRepo
    {
        private readonly ApplicationDbContext _context;

        public UserConnectionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public bool AddUserConnection(long connectionId, int userId)
        {

            var user = _context.Users.FirstOrDefault(x => x.Id == userId.ToString());

            if (user == null)
                return false;

            var connection = new UserConnection
            {
                ConnectedUserId = connectionId,
                User = user
            };
            _context.UserConnections.Add(connection);
            _context.SaveChanges();

            return true;

        }

        public bool RemoveUserConnection(long connectionId)
        {
            var connection = _context.UserConnections.FirstOrDefault(x => x.ConnectedUserId == connectionId);

            if (connection == null)
                return false;

            _context.Entry(connection).State = EntityState.Deleted;
            _context.SaveChanges();

            return true;

        }

        public IEnumerable<UserConnection> GetUserConnectionsIdsByUserId(long id)
        {
            var listOfConnections = _context.UserConnections.Where(x => x.User.Id == id.ToString());
            if (!listOfConnections.Any())
                return new List<UserConnection>();

            return listOfConnections;

        }

        public bool RemoveUserConnections(long id)
        {
            var listOfConnections = _context.UserConnections.Where(x => x.User.Id == id.ToString());
            if (!listOfConnections.Any())
                return false;

            foreach (var connection in listOfConnections)
            {
                _context.Entry(connection).State = EntityState.Deleted;
            }
            _context.SaveChanges();

            return true;
        }
    }
}