using System;
using System.ComponentModel.DataAnnotations;

namespace FreeChat.Models.DTO
{
    public class TopicsDto
    {
        public TopicsDto()
        {

        }

        public long Id { get; set; }
        [Required(ErrorMessage = "A Topic Name is required")]
        [StringLength(30)]
        public string Name { get; set; }


        public string Genre { get; set; }
        public bool Active { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpired { get; set; }
        [Required]
        public long MainCategoryId { get; set; }

        public string UserCreatorId { get; set; }
    }
}