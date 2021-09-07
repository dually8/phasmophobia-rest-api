using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhasmoRESTApi.Models
{
    public class Ghost
    {

        [Key]
        public long GhostId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }

        // Navigation Properties
        public ICollection<Ghost_Evidence> Ghost_Evidences { get; set; }

    }
}