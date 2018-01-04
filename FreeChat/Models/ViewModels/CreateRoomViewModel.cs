using FreeChat.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel;

namespace FreeChat.Models.ViewModels
{
    public class CreateRoomViewModel
    {
        [DisplayName("Category")]
        public IEnumerable<MainCategories> MainCategories { get; set; }

        [DisplayName("Chat Room Name")]
        public string ChatroomName { get; set; }

        public Topics Topic { get; set; }

        public CreateRoomViewModel()
        {

        }

    }
}