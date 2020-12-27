using AutoMapper;
using Skim.API.Entities;
using Skim.API.Models;

namespace Skim.API.Profiles
{
    public class ShortLinkProfile : Profile
    {
        public ShortLinkProfile()
        {
            CreateMap<ShortLink, ShortLinkDto>();
            CreateMap<ShortLinkDto, ShortLink>();
        }
    }
}