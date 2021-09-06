using System.ComponentModel.DataAnnotations;

namespace PhasmoRESTApi.Dtos
{
    public class GhostUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}