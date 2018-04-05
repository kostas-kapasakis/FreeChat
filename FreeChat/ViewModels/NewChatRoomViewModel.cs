﻿using System.Collections.Generic;
using System.ComponentModel;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;

namespace FreeChat.ViewModels
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