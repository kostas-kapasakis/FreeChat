using AutoMapper;
using FreeChat.Models.Domain;
using FreeChat.Models.DTO;

namespace FreeChat.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.Initialize(ini =>
            {
                ini.CreateMap<Topics, TopicsDto>();
                ini.CreateMap<TopicsDto, Topics>();
            });

        }
    }
}