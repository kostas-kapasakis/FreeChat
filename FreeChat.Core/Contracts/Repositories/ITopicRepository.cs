using FreeChat.Core.Models.Domain;
using System.Collections.Generic;

namespace FreeChat.Core.Contracts.Repositories
{
    public interface ITopicRepository : IGenericRepository<Topic>
    {
        IEnumerable<Topic> GetActiveTopics();

        IEnumerable<Topic> GetActiveTopicsByGenreId(long id);

        IEnumerable<MainCategory> GetMainCategories();

        bool AddTopic(Topic chatRoom, bool isAdmin);

        int DeleteTopicById(long id);

        IEnumerable<Topic> GetUserTopics(string id);

        int RoomsRemainingForUser(string id);

        bool ChangeTopicStatus(long id, bool status);




    }
}
