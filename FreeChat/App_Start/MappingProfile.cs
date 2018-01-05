using AutoMapper;
using FreeChat.Models.Domain;
using FreeChat.Models.DTO;

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
        }
    }
}