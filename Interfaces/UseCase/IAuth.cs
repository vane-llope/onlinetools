using onlinetools.Models;

namespace onlinetools.Interfaces.UseCase
{
    public interface IAuth
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string GenerateToken(User user);
    }
}
