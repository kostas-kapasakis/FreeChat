using System.Collections.Generic;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using FreeChat.Core.Models.Enums;

namespace FreeChat.Core.Contracts.Services
{
    public interface ITopicsService
    {
        Topics GetTopicById(long id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<TopicsDto> GetActiveTopicsByGenreId(long id);
        IEnumerable<MainCategoriesDto> GetMainCategories();
        bool AddTopic(TopicsDto chatRoom);
        TopicDeletionVerdictEnum DeleteTopicById(long id);
        TopicValidationPriorEnteringEnum ValidateRoom(long id);
        IEnumerable<TopicsDto> GetUserTopics(string id);
        int RoomsRemainingForUser(string id);
        IEnumerable<TopicsFullDto> GetTopicsFull();

        bool ChangeTopicStatus(long id, bool status);

    }
}
