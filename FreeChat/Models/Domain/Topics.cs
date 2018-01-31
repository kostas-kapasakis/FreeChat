using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreeChat.Models.Domain
{
    public class Topics
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

        public ApplicationUser UserCreator { get; set; }
        public string UserCreatorId { get; set; }

        [DisplayName("Main Categories")]
        public long MainCategoryId { get; set; }//convention that teats this property as an foreign key

        public virtual MainCategories MainCategory { get; set; }
    }
}