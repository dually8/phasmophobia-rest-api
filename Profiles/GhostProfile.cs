using AutoMapper;
using System.Linq;
using PhasmoRESTApi.Models;
using PhasmoRESTApi.Dtos;

namespace PhasmoRESTApi.Profiles
{
    public class GhostProfile : Profile
    {
        public GhostProfile()
        {
            // Source -> Target
            CreateMap<Ghost, GhostReadDto>()
                .ForMember(dest => dest.Evidence, opts => opts.MapFrom(ghost => ghost.Ghost_Evidences.Select(ge => ge.Evidence).ToList()));
            CreateMap<GhostCreateDto, Ghost>();
            CreateMap<GhostUpdateDto, Ghost>()
                .ReverseMap();
        }
    }
}
