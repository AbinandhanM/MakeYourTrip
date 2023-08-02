using System.ComponentModel.DataAnnotations;

namespace TravelPackage.Models
{
    public class TourDetails
    {
        [Key]
        public int TourId { get; set; }
        [Required]
        public int TravelAgentId { get; set; }


        [Required]
        public string? TourName { get; set; }

        [Required]
        public string? TourDescription { get; set; }

        [Required]
        public string? Tourtype { get; set; }

        [Required]
        public int TourPrice { get; set; }

        [Required]
        public int maxCapacity { get; set; }
        public int BookedCapacity { get; set; }
        [Required]
        public bool Availability{get; set;}

        public ICollection<TourDestination> TourDestination { get; set; }
        public ICollection<TourDate> TourDate { get; set; }
        
        public ICollection<TourInclusion> TourInclusion { get; set; }
        public ICollection<TourExclusion>   TourExclusion { get; set; }
    }
}
