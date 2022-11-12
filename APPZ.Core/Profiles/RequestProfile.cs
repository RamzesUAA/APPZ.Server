using APPZ.Core.DTO;
using APPZ.Core.Entities;
using AutoMapper;

namespace APPZ.Core.Profiles
{
    public class RequestProfile : Profile
    {
        public class AchievementProfile : Profile
        {
            public AchievementProfile()
            {
                CreateMap<RequestCreateDTO, RequestEntity>();
                CreateMap<RequestEntity, RequestReadDTO>().ForMember("Status", src => src.MapFrom(opt => opt.Status.ToString()));
            }
        }
    }
}
