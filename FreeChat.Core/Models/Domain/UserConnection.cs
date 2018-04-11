namespace FreeChat.Core.Models.Domain
{
    public class UserConnection
    {
        public long Id { get; set; }
        public long ConnectionId { get; set; }
        public string Username { get; set; }
        public ApplicationUser User { get; set; }
    }
}