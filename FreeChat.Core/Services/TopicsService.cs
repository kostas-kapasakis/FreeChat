using System;
using System.Collections.Generic;
using AutoMapper;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Contracts.UOW;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using FreeChat.Core.Models.Enums;

namespace FreeChat.Core.Services
{
    public class TopicsService : ITopicsService
    {
        private readonly ITopicsUnitOfWork _unitOfWork;

        public TopicsService(ITopicsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Topics GetTopicById(long id)
            => _unitOfWork.Topics.Get(id);

        public IEnumerable<Topics> GetActiveTopics()
            => _unitOfWork.Topics.GetActiveTopics();

        public IEnumerable<TopicsDto> GetActiveTopicsByGenreId(long id)
        {
            var topics = _unitOfWork.Topics.GetActiveTopicsByGenreId(id);
            return Mapper.Map<IEnumerable<Topics>, IEnumerable<TopicsDto>>(topics);
        }


        public IEnumerable<MainCategoriesDto> GetMainCategories()
        {
            var categories = _unitOfWork.Topics.GetMainCategories();
            return Mapper.Map<IEnumerable<MainCategories>, IEnumerable<MainCategoriesDto>>(categories);
        }

        public TopicValidationPriorEnteringEnum ValidateRoom(long id)
        {
            var topic = _unitOfWork.Topics.Get(id);
            if (topic == null)
            {
                return TopicValidationPriorEnteringEnum.RoomIsNotActivatedAnymore;
            }
            _unitOfWork.Complete();

            return topic.Active
                ? TopicValidationPriorEnteringEnum.RoomExistsAndisAvailable
                : TopicValidationPriorEnteringEnum.RoomExistsButIsnotAvailable;
        }



        public bool AddTopic(TopicsDto chatRoom)
        {        
            var user = _unitOfWork.User.Get(chatRoom.UserCreatorId);
            if (user == null || user.RoomsLeft == 0)
                return false;

            var adminVerdict = _unitOfWork.User.IsAdmin(user.Id);
            if (!adminVerdict)
                user.RoomsLeft--;

            if (chatRoom.DateCreated < DateTime.Today)
                chatRoom.DateCreated = DateTime.Today;

            chatRoom.DateExpired = chatRoom.DateCreated.AddDays(5);

            var topic = Mapper.Map<TopicsDto, Topics>(chatRoom);
            topic.MaxClientsOnline = 100;

           var result =  _unitOfWork.Topics.AddTopic(topic, adminVerdict);

            if (result)
                _unitOfWork.Complete();

            return _unitOfWork.Topics.AddTopic(topic , adminVerdict);
        }



        public TopicDeletionVerdictEnum DeleteTopicById(long id)
        {

            var verdict = _unitOfWork.Topics.DeleteTopicById(id);

            _unitOfWork.Complete();

            return verdict <= 0
                ? TopicDeletionVerdictEnum.TopicNotFound
                : TopicDeletionVerdictEnum.TopicSuccesfullyDeleted;
        }

        public IEnumerable<TopicsDto> GetUserTopics(string id)
        {
            var userTopics = _unitOfWork.Topics.GetUserTopics(id);
            return Mapper.Map<IEnumerable<Topics>, IEnumerable<TopicsDto>>(userTopics);
        }


        public int RoomsRemainingForUser(string userId)
        {
            return _unitOfWork.Topics.RoomsRemainingForUser(userId);
        }

        public IEnumerable<TopicsFullDto> GetTopicsFull()
        {
            var roomsFull = _unitOfWork.Topics.GetAll();
            return Mapper.Map<IEnumerable<Topics>, IEnumerable<TopicsFullDto>>(roomsFull);
        }

        public bool ChangeTopicStatus(long id, bool status)
        {
            var result = _unitOfWork.Topics.ChangeTopicStatus(id, status);
            if (!result) return false;

            _unitOfWork.Complete();
            return true;
        }
    }
}