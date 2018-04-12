using System;

namespace FreeChat.Core.Models.DTO
{
    public class TopicDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public bool Active { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateExpired { get; set; }

        public long MainCategoryId { get; set; }

        public string UserCreatorId { get; set; }
    }
}