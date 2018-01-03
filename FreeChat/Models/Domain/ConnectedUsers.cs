using FreeChat.Models.Identity;
using System.Collections.Generic;

namespace FreeChat.Models.Domain
{
    public class ConnectedUsers
    {
        public long Id { get; set; }
        public ApplicationUser ApplicationUserId { get; set; }
        public IList<UserConnections> UserConnections { get; set; }
        public string Username { get; set; }

    }
}