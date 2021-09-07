using System.Collections.Generic;

namespace PhasmoRESTApi.Dtos
{
    public class GhostReadDto
    {
        public long GhostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public List<string> Evidence { get; set; }
    }
}