using System.Collections.Generic;
using FreeChat.Core.Models.Domain;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface ITopicRepository:IGenericRepository<Topics>
    {
        IEnumerable<Topics> GetActiveTopics();
        IEnumerable<Topics> GetActiveTopicsByGenreId(long id);
        IEnumerable<MainCategories> GetMainCategories();
        bool AddTopic(Topics chatRoom, bool isAdmin);
        int DeleteTopicById(long id);
        IEnumerable<Topics> GetUserTopics(string id);
        int RoomsRemainingForUser(string id);


        bool ChangeTopicStatus(long id, bool status);




    }
}
