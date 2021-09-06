using System.ComponentModel.DataAnnotations;

namespace PhasmoRESTApi.Models
{
    public class Evidence
    {
        [Key]
        public long EvidenceId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }
    }
}