using FreeChat.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Contracts
{
    public interface ITopicsRepo
    {
        Topics GetTopicById(long Id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenre(string genre);
        bool AddTopic(Topics chatRoom);
        int DeleteTopicById(long Id);
    }
}
