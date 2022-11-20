using APPZ.Core.DTO;
using APPZ.Core.Entities;
using AutoMapper;

namespace APPZ.Core.Profiles
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<RequestCreateDTO, RequestEntity>().ReverseMap();
            CreateMap<RequestEntity, RequestReadDTO>().ForMember("Status", src => src.MapFrom(opt => opt.Status.ToString())).ReverseMap();
        }
    }
}
