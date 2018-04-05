using System.ComponentModel.DataAnnotations;

namespace FreeChat.Core.Models.Domain
{
    public class MainCategories
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public string CategoryImage { get; set; }

        public string CategoryDescription { get; set; }

       
    }
}