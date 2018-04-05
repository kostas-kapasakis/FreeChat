using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Models;
using FreeChat.Core.Models.Enums;

namespace FreeChat.Persistence.Repositories
{
    public class UserRepository :GenericRepository<ApplicationUser>, IUserRepository
    {
        private readonly FreeChatContext _freeChatContext;

        public UserRepository(FreeChatContext context)
            :base(context)
        {
            _freeChatContext = context;
        }

        public ApplicationUser GetUser(string id)
        {
            return _freeChatContext.Users.FirstOrDefault(i => i.Id == id);
        }

        public long CountRegisteredUsers()
        {
            return _freeChatContext.ConnectedUsers.Count();
        }

        public IEnumerable<ApplicationUser> GetRegisteredUsers()
        {
            return _freeChatContext.Users;
        }

        public bool UpdateUserStatus(bool status, string userId)
        {
            var user = _freeChatContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null) { return false; }

            user.Active = status;
            _freeChatContext.Entry(user).State = EntityState.Modified;
            _freeChatContext.SaveChanges();

            return true;
        }

        public bool IsAdmin(string userId)
        {
            var user = _freeChatContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return false;

            return user.Role == UsersRole.Admin;
        }


    }
}