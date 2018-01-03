using FreeChat.Contracts;
using FreeChat.Models.Domain;
using FreeChat.Models.Enums;
using System.Collections.Generic;

namespace FreeChat.Services
{
    public class TopicsService
    {
        private readonly ITopics _topicsRepository;

        public TopicsService(ITopics topicsRepository)
        {
            _topicsRepository = topicsRepository;
        }

        public Topics GetTopicById(long Id)
            => _topicsRepository.GetTopicById(Id);

        public IEnumerable<Topics> GetActiveTopics()
            => _topicsRepository.GetGetActiveTopics();

        public IEnumerable<Topics> GetActiveTopicsByGenre(string genre)
            => _topicsRepository.GetActiveTopicsByGenre(genre);

        public TopicDeletionVerdictEnum DeleteTopicById(long Id)
        {

            var verdict = _topicsRepository.DeleteTopicById(Id);

            return verdict <= 0
                ? TopicDeletionVerdictEnum.TopicNotFound
                : TopicDeletionVerdictEnum.TopicSuccesfullyDeleted;
        }
    }
}