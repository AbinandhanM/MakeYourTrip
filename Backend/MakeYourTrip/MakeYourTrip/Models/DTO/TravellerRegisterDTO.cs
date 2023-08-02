using System.ComponentModel.DataAnnotations;

namespace LoginAndRegister.Models.DTO
{
    public class TravellerRegisterDTO:Traveller
    {
        [Required]
        public string? PasswordClear { get; set; }
    }
}
