using LoginAndRegister.Models;
using LoginAndRegister.Models.DTO;

namespace LoginAndRegister.Interfaces
{
    public interface IManageUser
    {
        public Task<UserDTO> Login(LoginDTO loginDTO);
        public Task<User> UpdatePassword(PasswordChangeDTO pass);

    }
}
