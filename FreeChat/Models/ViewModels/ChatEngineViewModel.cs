using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeChat.Models.ViewModels
{
    public class ChatEngineViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}