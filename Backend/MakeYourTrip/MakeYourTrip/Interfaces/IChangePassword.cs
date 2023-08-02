using LoginAndRegister.Models;

namespace LoginAndRegister.Interfaces
{
    public interface IChangePassword:IBaseCRUD<string, User>
    {
        public Task<User> ChangePassword(Byte[] PasswordHash, Byte[] PasswordKey, User user, string NewPassword);

    }
}
