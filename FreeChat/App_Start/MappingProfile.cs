using AutoMapper;
using FreeChat.Core.Models;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;

namespace FreeChat.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Topic, TopicDto>();
            CreateMap<TopicDto, Topic>();
            CreateMap<MainCategory, MainCategoryDto>();
            CreateMap<MainCategoryDto, MainCategory>();
            CreateMap<Topic, TopicDto>();
            CreateMap<TopicDto, Topic>();
            CreateMap<Topic, TopicExtendedDto>();
            CreateMap<TopicExtendedDto, Topic>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}