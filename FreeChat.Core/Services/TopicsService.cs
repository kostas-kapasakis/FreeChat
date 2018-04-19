using AutoMapper;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Contracts.UOW;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;
using FreeChat.Core.Models.Enums;
using System;
using System.Collections.Generic;

namespace FreeChat.Core.Services
{
    public class TopicsService : ITopicsService
    {
        private readonly ITopicsUnitOfWork _unitOfWork;

        public TopicsService(ITopicsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Topic GetTopic(long id)
            => _unitOfWork.Topics.Get(id);

        public IEnumerable<TopicDto> GetActiveTopics()
        {
            var topics = _unitOfWork.Topics.GetActiveTopics();

            return Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicDto>>(topics);
        }


        public IEnumerable<TopicDto> GetTopicsExtended()
        {
            var topics = _unitOfWork.Topics.GetAll();
            return Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicDto>>(topics);

        }

        public IEnumerable<TopicDto> GetActiveTopicsByGenreId(long id)
        {
            var topics = _unitOfWork.Topics.GetActiveTopicsByGenreId(id);
            return Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicDto>>(topics);
        }


        public IEnumerable<MainCategoryDto> GetMainCategories()
        {
            var categories = _unitOfWork.Topics.GetMainCategories();
            return Mapper.Map<IEnumerable<MainCategory>, IEnumerable<MainCategoryDto>>(categories);
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



        public bool AddTopic(TopicDto chatRoom)
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

            var topic = Mapper.Map<TopicDto, Topic>(chatRoom);
            topic.MaxClientsOnline = 100;

            var result = _unitOfWork.Topics.AddTopic(topic, adminVerdict);

            if (result)
                _unitOfWork.Complete();

            return _unitOfWork.Topics.AddTopic(topic, adminVerdict);
        }



        public TopicDeletionVerdictEnum DeleteTopicById(long id)
        {

            var verdict = _unitOfWork.Topics.DeleteTopicById(id);

            _unitOfWork.Complete();

            return verdict <= 0
                ? TopicDeletionVerdictEnum.TopicNotFound
                : TopicDeletionVerdictEnum.TopicSuccesfullyDeleted;
        }

        public IEnumerable<TopicDto> GetUserTopics(string id)
        {
            var userTopics = _unitOfWork.Topics.GetUserTopics(id);
            return Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicDto>>(userTopics);
        }


        public int RoomsRemainingForUser(string userId)
        {
            return _unitOfWork.Topics.RoomsRemainingForUser(userId);
        }

        public IEnumerable<TopicExtendedDto> GetTopicsFull()
        {
            var roomsFull = _unitOfWork.Topics.GetAll();
            return Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicExtendedDto>>(roomsFull);
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