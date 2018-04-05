namespace FreeChat.Core.Models.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int RoomsLeft { get; set; }
        public string Role { get; set; }
    }
}