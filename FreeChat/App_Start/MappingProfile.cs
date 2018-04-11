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

            CreateMap<Topic, TopicsDto>();
            CreateMap<TopicsDto, Topic>();
            CreateMap<MainCategory, MainCategoriesDto>();
            CreateMap<MainCategoriesDto, MainCategory>();
            CreateMap<Topic, TopicsDto>();
            CreateMap<TopicsDto, Topic>();
            CreateMap<Topic, TopicsFullDto>();
            CreateMap<TopicsFullDto, Topic>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();

        }
    }
}