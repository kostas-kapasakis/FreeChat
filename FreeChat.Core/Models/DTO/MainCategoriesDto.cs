using System;

namespace FreeChat.Core.Models.DTO
{
    public class MainCategoriesDto
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public string CategoryImage { get; set; }

        public string CategoryDescription { get; set; }

        public DateTime DateExpired { get; set; }
    }
}