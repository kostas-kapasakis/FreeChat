using System.Collections.Generic;
using FreeChat.Models.Domain;

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

    }
}
