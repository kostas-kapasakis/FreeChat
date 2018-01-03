using FreeChat.Models.Domain;
using FreeChat.Models.DTO;
using System.Collections.Generic;

namespace FreeChat.Contracts
{
    public interface ITopicsRepo
    {
        Topics GetTopicById(long Id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenre(string genre);
        bool AddTopic(CreateChatRoomDto chatRoom);
        int DeleteTopicById(long Id);
    }
}
