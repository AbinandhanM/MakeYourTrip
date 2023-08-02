using System.ComponentModel.DataAnnotations;

namespace LoginAndRegister.Models.DTO
{
    public class AdminRegisterDTO:Admin
    {
        [Required]
        public string PasswordClear { get; set; }
    }
}
