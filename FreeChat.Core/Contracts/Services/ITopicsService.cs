using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using FreeChat.Core.Models.Enums;
using System.Collections.Generic;

namespace FreeChat.Core.Contracts.Services
{
    public interface ITopicsService
    {
        Topic GetTopic(long id);

        IEnumerable<Topic> GetActiveTopics();

        IEnumerable<TopicsDto> GetActiveTopicsByGenreId(long id);

        IEnumerable<MainCategoriesDto> GetMainCategories();

        bool AddTopic(TopicsDto chatRoom);

        TopicDeletionVerdictEnum DeleteTopicById(long id);

        TopicValidationPriorEnteringEnum ValidateRoom(long id);

        IEnumerable<TopicsDto> GetUserTopics(string id);

        int RoomsRemainingForUser(string id);


        bool ChangeTopicStatus(long id, bool status);

    }
}
