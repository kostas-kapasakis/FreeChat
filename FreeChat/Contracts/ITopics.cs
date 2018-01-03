using FreeChat.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Contracts
{
    public interface ITopics
    {
        Topics GetTopicById(long Id);
        IEnumerable<Topics> GetGetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenre(string genre);
        int DeleteTopicById(long Id);
    }
}
