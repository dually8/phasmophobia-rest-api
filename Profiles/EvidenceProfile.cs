using AutoMapper;
using PhasmoRESTApi.Models;
using PhasmoRESTApi.Dtos;

namespace PhasmoRESTApi.Profiles
{
    public class EvidenceProfile : Profile
    {
        public EvidenceProfile()
        {
            // Source -> Target
            CreateMap<Evidence, EvidenceReadDto>()
                .ReverseMap();
            CreateMap<EvidenceCreateDto, Evidence>();
            CreateMap<EvidenceUpdateDto, Evidence>()
                .ReverseMap(); // let's us use the reverse as well (Evidence -> EvidenceUpdateDto)
        }
    }
}
