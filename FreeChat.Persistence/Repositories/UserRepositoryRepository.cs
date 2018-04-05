using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Models;
using FreeChat.Core.Models.Enums;

namespace FreeChat.Persistence.Repositories
{
    public class UserRepositoryRepository : IUsers
    {
        private readonly FreeChatContext FreeChatContext;

        public UserRepositoryRepository(FreeChatContext context)
        {
            FreeChatContext = context;
        }

        public ApplicationUser GetUser(string id)
        {
            return FreeChatContext.Users.FirstOrDefault(i => i.Id == id);
        }

        public long CountRegisteredUsers()
        {
            return FreeChatContext.ConnectedUsers.Count();
        }

        public IEnumerable<ApplicationUser> GetRegisteredUsers()
        {
            return FreeChatContext.Users;
        }

        public bool UpdateUserStatus(bool status, string userId)
        {
            var user = FreeChatContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null) { return false; }

            user.Active = status;
            FreeChatContext.Entry(user).State = EntityState.Modified;
            FreeChatContext.SaveChanges();

            return true;
        }

        public bool IsAdmin(string userId)
        {
            var user = FreeChatContext.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return false;

            return user.Role == UsersRole.Admin;
        }


    }
}