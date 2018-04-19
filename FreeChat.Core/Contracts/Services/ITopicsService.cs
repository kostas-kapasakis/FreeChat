using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using FreeChat.Core.Models.Enums;
using System.Collections.Generic;

namespace FreeChat.Core.Contracts.Services
{
    public interface ITopicsService
    {
        Topic GetTopic(long id);

        IEnumerable<TopicDto> GetActiveTopics();

        IEnumerable<TopicDto> GetTopicsExtended();

        IEnumerable<TopicDto> GetActiveTopicsByGenreId(long id);

        IEnumerable<MainCategoryDto> GetMainCategories();

        bool AddTopic(TopicDto chatRoom);

        TopicDeletionVerdictEnum DeleteTopicById(long id);

        TopicValidationPriorEnteringEnum ValidateRoom(long id);

        IEnumerable<TopicDto> GetUserTopics(string id);

        int RoomsRemainingForUser(string id);


        bool ChangeTopicStatus(long id, bool status);

    }
}
