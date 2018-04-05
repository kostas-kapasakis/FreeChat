using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreeChat.Core.Models.DTO
{
    public class TopicsFullDto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Room Name")]
        public string Name { get; set; }

        public string Genre { get; set; }

        [StringLength(250)]
        [Required]
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpired { get; set; }
        public long MaxClientsOnline { get; set; }
        public string UserCreatorId { get; set; }
        public long MainCategoryId { get; set; }
    }
}