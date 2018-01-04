using System.Collections.Generic;
using FreeChat.Models.Domain;
using FreeChat.Models.DTO;
using FreeChat.Models.Enums;

namespace FreeChat.Services.ServicesInterfaces
{
    public interface ITopicsService
    {
        Topics GetTopicById(long Id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenre(string genre);
        IEnumerable<MainCategories> GetMainCategories();
        bool AddTopic(TopicsDto chatRoom);
        TopicDeletionVerdictEnum DeleteTopicById(long Id);
    }
}
