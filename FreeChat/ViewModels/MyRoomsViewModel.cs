using System.Collections.Generic;
using FreeChat.Core.Models.DTO;

namespace FreeChat.ViewModels
{
    public class MyRoomsViewModel
    {
        public IEnumerable<TopicDto> MyTopics { get; set; }

    }
}