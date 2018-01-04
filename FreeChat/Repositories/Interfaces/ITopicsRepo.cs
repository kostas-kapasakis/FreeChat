using System.Collections.Generic;
using FreeChat.Models.Domain;

namespace FreeChat.Repositories.Interfaces
{
    public interface ITopicsRepo
    {
        Topics GetTopicById(long Id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenre(string genre);
        IEnumerable<MainCategories> GetMainCategories();
        bool AddTopic(Topics chatRoom);
        int DeleteTopicById(long Id);

    }
}
