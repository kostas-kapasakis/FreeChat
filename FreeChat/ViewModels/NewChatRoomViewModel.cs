using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FreeChat.Web.ViewModels
{
    public class NewChatRoomViewModel
    {
        [DisplayName("Category")]
        public IEnumerable<MainCategory> MainCategories { get; set; }

        public int MainCategoryId { get; set; }

        [Required(ErrorMessage = "Room name is required")]
        [MaxLength(50)]
        public string RoomName { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        
        public Topic Topic { get; set; }


        public int RoomsLeft { get; set; }

        public int RoomsCreated { get; set; }

        public IEnumerable<TopicDto> UserTopics { get; set; }
    }
}

/*https://stackoverflow.com/questions/8894367/how-to-make-fluent-api-configuration-work-with-mvc-client-side-validation*/
