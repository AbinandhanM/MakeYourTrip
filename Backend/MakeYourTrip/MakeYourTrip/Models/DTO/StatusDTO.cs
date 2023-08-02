using System.ComponentModel.DataAnnotations;

namespace LoginAndRegister.Models.DTO
{
    public class StatusDTO
    {
        [Required]
        public string EmailId { get; set; }
        public string Status { get; set; }
    }
}
