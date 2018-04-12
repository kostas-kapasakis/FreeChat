using System.Collections.Generic;

namespace FreeChat.Core.Models.Domain
{
    public class ConnectedUser
    {
        public ConnectedUser()
        {
            UserConnections = new List<UserConnection>();
        }

        public long Id { get; set; }

        public User User { get; set; }

        public IList<UserConnection> UserConnections { get; set; }

        public string Username { get; set; }

    }
}