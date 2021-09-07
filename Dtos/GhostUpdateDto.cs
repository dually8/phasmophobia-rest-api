using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhasmoRESTApi.Dtos
{
    public class GhostUpdateDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public List<long> EvidenceIds { get; set; }
    }
}