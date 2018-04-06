using System.Data.Entity;
using System.Linq;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Models;
using FreeChat.Core.Models.Enums;

namespace FreeChat.Persistence.Repositories
{
    public class UserRepository :GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(FreeChatContext context)
            :base(context)
        {
        }

        public long CountRegisteredUsers()
        {
            return FreeChatContext.ConnectedUsers.Count();
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

        public FreeChatContext FreeChatContext => Context as FreeChatContext;

    }
}