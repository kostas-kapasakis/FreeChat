using FreeChat.Models;
using FreeChat.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FreeChat.Repositories
{
    public class UsersRepository : IUsers
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public long CountRegisteredUsers()
        {
            return _context.ConnectedUsers.Count();
        }

        public IEnumerable<ApplicationUser> GetRegisteredUsers()
        {
            return _context.Users;
        }


    }
}