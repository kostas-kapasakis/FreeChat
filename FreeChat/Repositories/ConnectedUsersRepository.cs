using FreeChat.Contracts;
using FreeChat.Models;
using FreeChat.Models.Identity;
using System.Collections.Generic;
using System.Linq;

namespace FreeChat.Repositories
{
    public class ConnectedUsersRepository : IConnectedUsers
    {
        private readonly ApplicationDbContext _context;

        public ConnectedUsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public long CountConnectedUsers()
        {
            return _context.ConnectedUsers.Count();
        }

        public IEnumerable<ApplicationUser> GetConnectedUsers()
        {
            return _context.Users;
        }
    }
}