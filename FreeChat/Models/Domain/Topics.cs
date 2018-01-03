using System;

namespace FreeChat.Models.Domain
{
    public class Topics
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpired { get; set; }
        public long MaxClientsOnline { get; set; }

    }
}