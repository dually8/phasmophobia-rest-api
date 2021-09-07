using System.Collections.Generic;

namespace PhasmoRESTApi.Models
{
    public class Ghost_Evidence
    {
        public int Id { get; set; }

        // Navigation Properties

        public long GhostId { get; set; }
        public Ghost Ghost { get; set; }
        public long EvidenceId { get; set; }
        public Evidence Evidence { get; set; }
    }
}
