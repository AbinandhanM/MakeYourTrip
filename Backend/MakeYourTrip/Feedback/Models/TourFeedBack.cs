using System.ComponentModel.DataAnnotations;

namespace Feedback.Models
{
    public class TourFeedBack
    {

        [Key]
        public int FeedbackId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TouristName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        public string FeedbackText { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public DateTime DateSubmitted { get; set; }
    
    }
}
