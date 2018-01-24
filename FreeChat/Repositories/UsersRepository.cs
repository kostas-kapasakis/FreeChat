using FreeChat.Models;
using FreeChat.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool UpdateUserStatus(bool status, string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null) { return false; }

            user.Active = status;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }


    }
}