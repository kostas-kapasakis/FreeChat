using System;

namespace FreeChat.Core.Models.Domain
{
    public class Message
    {
        public long Id { get; set; }

        public string MessageSent { get; set; }

        public DateTime DateSent { get; set; }

        public ApplicationUser User { get; set; }
    }
}
