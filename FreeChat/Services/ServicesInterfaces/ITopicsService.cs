using FreeChat.Models.Domain;
using FreeChat.Models.DTO;
using FreeChat.Models.Enums;
using System.Collections.Generic;

namespace FreeChat.Services.ServicesInterfaces
{
    public interface ITopicsService
    {
        Topics GetTopicById(long Id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenre(string genre);
        IEnumerable<MainCategoriesDto> GetMainCategories();
        bool AddTopic(TopicsDto chatRoom);
        TopicDeletionVerdictEnum DeleteTopicById(long Id);
    }
}
