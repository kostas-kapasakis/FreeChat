using FreeChat.Models.Domain;
using FreeChat.Models.DTO;
using FreeChat.Models.Enums;
using System.Collections.Generic;

namespace FreeChat.Services.ServicesInterfaces
{
    public interface ITopicsService
    {
        Topics GetTopicById(long id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenreId(long id);
        IEnumerable<MainCategoriesDto> GetMainCategories();
        bool AddTopic(TopicsDto chatRoom);
        TopicDeletionVerdictEnum DeleteTopicById(long id);
    }
}
