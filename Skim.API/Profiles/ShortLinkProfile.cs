using AutoMapper;

namespace Skim.API.Profiles
{
    public class ShortLinkProfile : Profile
    {
        public ShortLinkProfile()
        {
            CreateMap<Entities.ShortLink, Models.ShortLinkDto>();
            CreateMap<Models.ShortLinkDto, Entities.ShortLink>();
        }
    }
}