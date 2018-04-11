using System.Collections.Generic;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface ITopicsRepo
    {
        Topic GetTopicById(long id);
        IEnumerable<Topic> GetActiveTopics();
        IEnumerable<Topic> GetActiveTopicsByGenreId(long id);
        IEnumerable<MainCategory> GetMainCategories();
        bool AddTopic(Topic chatRoom);
        int DeleteTopicById(long id);
        IEnumerable<Topic> GetUserTopics(string id);
        int RoomsRemainingForUser(string id);


        bool ChangeTopicStatus(long id, bool status);
        IEnumerable<Topic> GetTopicsFull();



    }
}
