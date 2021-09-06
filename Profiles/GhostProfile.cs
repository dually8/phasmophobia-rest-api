using AutoMapper;
using PhasmoRESTApi.Models;
using PhasmoRESTApi.Dtos;

namespace PhasmoRESTApi.Profiles
{
    public class GhostProfile : Profile
    {
        public GhostProfile()
        {
            // Source -> Target
            CreateMap<Ghost, GhostReadDto>();
            CreateMap<GhostCreateDto, Ghost>();
            CreateMap<GhostUpdateDto, Ghost>();
            CreateMap<Ghost, GhostUpdateDto>();
        }
    }
}
