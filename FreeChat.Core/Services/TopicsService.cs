using System;
using System.Collections.Generic;
using AutoMapper;
using FreeChat.Core.Contracts.Repositories;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using FreeChat.Core.Models.Enums;

namespace FreeChat.Core.Services
{
    public class TopicsService : ITopicsService
    {
        private readonly ITopicRepository _topicsRepoRepository;

        public TopicsService(ITopicRepository topicsRepoRepository)
        {
            _topicsRepoRepository = topicsRepoRepository;
        }

        public Topics GetTopicById(long id)
            => _topicsRepoRepository.GetTopicById(id);

        public IEnumerable<Topics> GetActiveTopics()
            => _topicsRepoRepository.GetActiveTopics();

        public IEnumerable<TopicsDto> GetActiveTopicsByGenreId(long id)
        {
            var topics = _topicsRepoRepository.GetActiveTopicsByGenreId(id);
            return Mapper.Map<IEnumerable<Topics>, IEnumerable<TopicsDto>>(topics);
        }


        public IEnumerable<MainCategoriesDto> GetMainCategories()
        {
            var categories = _topicsRepoRepository.GetMainCategories();

            return Mapper.Map<IEnumerable<MainCategories>, IEnumerable<MainCategoriesDto>>(categories);

        }

        public TopicValidationPriorEnteringEnum ValidateRoom(long id)
        {
            var topic = _topicsRepoRepository.GetTopicById(id);
            if (topic == null)
            {
                return TopicValidationPriorEnteringEnum.RoomIsNotActivatedAnymore;
            }

            return topic.Active
                ? TopicValidationPriorEnteringEnum.RoomExistsAndisAvailable
                : TopicValidationPriorEnteringEnum.RoomExistsButIsnotAvailable;
        }



        public bool AddTopic(TopicsDto chatRoom)
        {
            if (chatRoom.DateCreated < DateTime.Today)
                chatRoom.DateCreated = DateTime.Today;

            chatRoom.DateExpired = chatRoom.DateCreated.AddDays(5);

            var topic = Mapper.Map<TopicsDto, Topics>(chatRoom);
            topic.MaxClientsOnline = 100;

            return _topicsRepoRepository.AddTopic(topic);
        }



        public TopicDeletionVerdictEnum DeleteTopicById(long id)
        {

            var verdict = _topicsRepoRepository.DeleteTopicById(id);

            return verdict <= 0
                ? TopicDeletionVerdictEnum.TopicNotFound
                : TopicDeletionVerdictEnum.TopicSuccesfullyDeleted;
        }



        public IEnumerable<TopicsDto> GetUserTopics(string id)
        {
            var userTopics = _topicsRepoRepository.GetUserTopics(id);
            return Mapper.Map<IEnumerable<Topics>, IEnumerable<TopicsDto>>(userTopics);
        }


        public int RoomsRemainingForUser(string userId)
        {
            return _topicsRepoRepository.RoomsRemainingForUser(userId);
        }

        public IEnumerable<TopicsFullDto> GetTopicsFull()
        {
            var roomsFull = _topicsRepoRepository.GetTopicsFull();
            return Mapper.Map<IEnumerable<Topics>, IEnumerable<TopicsFullDto>>(roomsFull);
        }

        public bool ChangeTopicStatus(long id, bool status)
        {
            return _topicsRepoRepository.ChangeTopicStatus(id, status);
        }
    }
}