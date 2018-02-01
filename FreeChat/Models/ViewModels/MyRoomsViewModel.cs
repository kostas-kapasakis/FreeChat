using FreeChat.Models.DTO;
using System.Collections.Generic;

namespace FreeChat.Models.ViewModels
{
    public class MyRoomsViewModel
    {
        public IEnumerable<TopicsDto> MyTopics { get; set; }

    }
}