using System.ComponentModel.DataAnnotations;

namespace LoginAndRegister.Models.DTO
{
    public class TravelAgentRegisterDTO:TravelAgent
    {
        [Required]
        public string? PasswordClear { get; set; }
    }
}
