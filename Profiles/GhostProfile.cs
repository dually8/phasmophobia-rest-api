using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using PhasmoRESTApi.Models;
using PhasmoRESTApi.Dtos;
using PhasmoRESTApi.Data;

namespace PhasmoRESTApi.Profiles
{
    public class GhostProfile : Profile
    {
        public GhostProfile()
        {
            // Source -> Target
            CreateMap<Ghost, GhostReadDto>()
                .ForMember(dest => dest.Evidence, opts => opts.MapFrom<EvidenceResolver>());
            //.ForMember(dest => dest.Evidence, opts => opts.MapFrom(ghost => ghost.Ghost_Evidences.Select(ge => ge.Evidence.Name).ToList()));
            // .AfterMap((ghost, ghostReadDto) =>
            // {
            //     foreach (var ge in ghost.Ghost_Evidences)
            //     {
            //         ge.Evidence = _evidenceRepo.GetEvidenceById(ge.EvidenceId);
            //     }
            //     ghostReadDto.Evidence = ghost.Ghost_Evidences.Select(ge => ge.Evidence.Name).ToList();
            // });
            CreateMap<GhostCreateDto, Ghost>();
            CreateMap<GhostUpdateDto, Ghost>()
                .ReverseMap();
        }
    }

    public class EvidenceResolver : IValueResolver<Ghost, GhostReadDto, List<string>>
    {
        private readonly IEvidenceRepo _evidenceRepo;
        public EvidenceResolver(IEvidenceRepo evidenceRepo)
        {
            _evidenceRepo = evidenceRepo;
        }
        public List<string> Resolve(Ghost source, GhostReadDto destination, List<string> destMember, ResolutionContext context)
        {
            foreach (var ge in source.Ghost_Evidences)
            {
                ge.Evidence = _evidenceRepo.GetEvidenceById(ge.EvidenceId);
            }
            return source.Ghost_Evidences.Select(ge => ge.Evidence.Name).ToList();
        }
    }
}
