using FreeChat.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel;

namespace FreeChat.Models.ViewModels
{
    public class NewChatRoomViewModel
    {
        [DisplayName("Category")]
        public IEnumerable<MainCategories> MainCategories { get; set; }
        public Topics Topic { get; set; }
    }
}