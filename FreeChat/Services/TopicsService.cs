using FreeChat.Contracts;
using FreeChat.Models.Domain;
using FreeChat.Models.Enums;
using System.Collections.Generic;

namespace FreeChat.Services
{
    public class TopicsService
    {
        private readonly ITopicsRepo _topicsRepoRepository;

        public TopicsService(ITopicsRepo topicsRepoRepository)
        {
            _topicsRepoRepository = topicsRepoRepository;
        }

        public Topics GetTopicById(long Id)
            => _topicsRepoRepository.GetTopicById(Id);

        public IEnumerable<Topics> GetActiveTopics()
            => _topicsRepoRepository.GetActiveTopics();

        public IEnumerable<Topics> GetActiveTopicsByGenre(string genre)
            => _topicsRepoRepository.GetActiveTopicsByGenre(genre);

        public TopicDeletionVerdictEnum DeleteTopicById(long Id)
        {

            var verdict = _topicsRepoRepository.DeleteTopicById(Id);

            return verdict <= 0
                ? TopicDeletionVerdictEnum.TopicNotFound
                : TopicDeletionVerdictEnum.TopicSuccesfullyDeleted;
        }
    }
}