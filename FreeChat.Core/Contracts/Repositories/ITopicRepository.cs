using System.Collections.Generic;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface ITopicRepository:IGenericRepository<Topics>
    {
        Topics GetTopicById(long id);
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenreId(long id);
        IEnumerable<MainCategories> GetMainCategories();
        bool AddTopic(Topics chatRoom);
        int DeleteTopicById(long id);
        IEnumerable<Topics> GetUserTopics(string id);
        int RoomsRemainingForUser(string id);


        bool ChangeTopicStatus(long id, bool status);
        IEnumerable<Topics> GetTopicsFull();



    }
}
