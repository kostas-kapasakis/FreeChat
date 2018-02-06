using FreeChat.Models;
using FreeChat.Models.Enums;
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

        public ApplicationUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(i => i.Id == id);
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

        public bool IsAdmin(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return false;

            return user.Role == UsersRole.Admin;
        }


    }
}