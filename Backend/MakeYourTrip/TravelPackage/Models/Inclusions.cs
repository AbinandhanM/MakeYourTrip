using System.ComponentModel.DataAnnotations;

namespace TravelPackage.Models
{
    public class Inclusions
    {

        [Key]
        public int InclusionId { get; set; }
        [Required]
        public string? InclusionDescriptionn { get; set; }
    }
}
