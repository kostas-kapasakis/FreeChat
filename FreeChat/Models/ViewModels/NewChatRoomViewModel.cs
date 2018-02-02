using FreeChat.Models.Domain;
using FreeChat.Models.DTO;
using System.Collections.Generic;
using System.ComponentModel;

namespace FreeChat.Models.ViewModels
{
    public class NewChatRoomViewModel
    {
        [DisplayName("Category")]
        public IEnumerable<MainCategories> MainCategories { get; set; }
        public Topics Topic { get; set; }
        public int RoomsLeft { get; set; }
        public int RoomsCreated { get; set; }
        public IEnumerable<TopicsDto> UserTopics { get; set; }
    }
}