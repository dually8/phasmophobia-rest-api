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
            CreateMap<Evidence, EvidenceReadDto>();
            CreateMap<EvidenceCreateDto, Evidence>();
            CreateMap<EvidenceUpdateDto, Evidence>();
            CreateMap<Evidence, EvidenceUpdateDto>();
        }
    }
}
