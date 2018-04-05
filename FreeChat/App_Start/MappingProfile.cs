using AutoMapper;
using FreeChat.Core.Models;
using FreeChat.Core.Models.Domain;
using FreeChat.Core.Models.DTO;

namespace FreeChat
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Topics, TopicsDto>();
            CreateMap<TopicsDto, Topics>();
            CreateMap<MainCategories, MainCategoriesDto>();
            CreateMap<MainCategoriesDto, MainCategories>();
            CreateMap<Topics, TopicsDto>();
            CreateMap<TopicsDto, Topics>();
            CreateMap<Topics, TopicsFullDto>();
            CreateMap<TopicsFullDto, Topics>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();

        }
    }
}