using AutoMapper;
using FreeChat.Models.Domain;
using FreeChat.Models.DTO;
using FreeChat.Models.Enums;
using FreeChat.Repositories.Interfaces;
using FreeChat.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;

namespace FreeChat.Services
{
    public class TopicsService : ITopicsService
    {
        private readonly ITopicsRepo _topicsRepoRepository;

        public TopicsService(ITopicsRepo topicsRepoRepository)
        {
            _topicsRepoRepository = topicsRepoRepository;
        }

        public Topics GetTopicById(long id)
            => _topicsRepoRepository.GetTopicById(id);

        public IEnumerable<Topics> GetActiveTopics()
            => _topicsRepoRepository.GetActiveTopics();

        public IEnumerable<Topics> GetActiveTopicsByGenreId(long id)
            => _topicsRepoRepository.GetActiveTopicsByGenreId(id);

        public IEnumerable<MainCategoriesDto> GetMainCategories()
        {
            var categories = _topicsRepoRepository.GetMainCategories();

            return Mapper.Map<IEnumerable<MainCategories>, IEnumerable<MainCategoriesDto>>(categories);

        }



        public bool AddTopic(TopicsDto chatRoom)
        {
            if (chatRoom.DateCreated < DateTime.Today)
                chatRoom.DateCreated = DateTime.Today;

            chatRoom.DateExpired = chatRoom.DateCreated.AddDays(10);

            var topic = Mapper.Map<TopicsDto, Topics>(chatRoom);

            return _topicsRepoRepository.AddTopic(topic);
        }



        public TopicDeletionVerdictEnum DeleteTopicById(long id)
        {

            var verdict = _topicsRepoRepository.DeleteTopicById(id);

            return verdict <= 0
                ? TopicDeletionVerdictEnum.TopicNotFound
                : TopicDeletionVerdictEnum.TopicSuccesfullyDeleted;
        }
    }
}