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

        public Topics GetTopicById(long Id)
            => _topicsRepoRepository.GetTopicById(Id);

        public IEnumerable<Topics> GetActiveTopics()
            => _topicsRepoRepository.GetActiveTopics();

        public IEnumerable<Topics> GetActiveTopicsByGenre(string genre)
            => _topicsRepoRepository.GetActiveTopicsByGenre(genre);

        public IEnumerable<MainCategories> GetMainCategories()
            => _topicsRepoRepository.GetMainCategories();

        public bool AddTopic(TopicsDto chatRoom)
        {
            if (chatRoom.DateCreated < DateTime.Today)
                chatRoom.DateCreated = DateTime.Today;

            chatRoom.DateExpired = chatRoom.DateCreated.AddDays(10);

            var topic = Mapper.Map<TopicsDto, Topics>(chatRoom);

            return _topicsRepoRepository.AddTopic(topic);
        }



        public TopicDeletionVerdictEnum DeleteTopicById(long Id)
        {

            var verdict = _topicsRepoRepository.DeleteTopicById(Id);

            return verdict <= 0
                ? TopicDeletionVerdictEnum.TopicNotFound
                : TopicDeletionVerdictEnum.TopicSuccesfullyDeleted;
        }
    }
}