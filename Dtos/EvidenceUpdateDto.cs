using System.ComponentModel.DataAnnotations;

namespace PhasmoRESTApi.Dtos
{
    public class EvidenceUpdateDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }
    }
}