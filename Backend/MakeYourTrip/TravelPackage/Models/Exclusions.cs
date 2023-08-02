using System.ComponentModel.DataAnnotations;

namespace TravelPackage.Models
{
    public class Exclusions
    {
        [Key]
        public  int ExclusionId { get; set; }
        [Required]
        public string? ExclusionDescriptionn { get; set; }
    }
}
