namespace FreeChat.Core.Models.Domain
{
    public class UserConnection
    {
        public long Id { get; set; }

        public ConnectedUser ConnectedUser { get; set; }

        public long ConnectedUserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}