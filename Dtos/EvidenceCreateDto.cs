using System.ComponentModel.DataAnnotations;

namespace PhasmoRESTApi.Dtos
{
    public class EvidenceCreateDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }
    }
}