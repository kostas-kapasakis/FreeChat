using FreeChat.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Contracts
{
    public interface ITopicsRepo
    {
        Topics GetTopicById(long Id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenre(string genre);
        int DeleteTopicById(long Id);
    }
}
