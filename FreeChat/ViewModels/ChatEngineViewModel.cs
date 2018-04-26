using FreeChat.Core.Models.Enums.ChatEngineEnums;
using System;

namespace FreeChat.Web.ViewModels
{
    public class ChatEngineViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public OnlineUsersSituationEnum OnlineUsersOptions { get; set; }
    }
}