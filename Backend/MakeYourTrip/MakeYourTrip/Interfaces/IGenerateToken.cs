using LoginAndRegister.Models.DTO;

namespace LoginAndRegister.Interfaces
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserDTO user);

    }
}
