using FreeChat.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Repositories.Interfaces
{
    public interface ITopicsRepo
    {
        Topics GetTopicById(long id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenreId(long id);
        IEnumerable<MainCategories> GetMainCategories();
        bool AddTopic(Topics chatRoom);
        int DeleteTopicById(long id);
        IEnumerable<Topics> GetUserTopics(string id);
        int RoomsRemainingForUser(string id);
    }
}
