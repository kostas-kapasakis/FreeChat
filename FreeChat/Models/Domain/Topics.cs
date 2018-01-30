using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeChat.Models.Domain
{
    public class Topics
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpired { get; set; }
        public long MaxClientsOnline { get; set; }

        public long MainCategoryId { get; set; }
        
        public virtual MainCategories MainCategory { get; set; }
    }
}