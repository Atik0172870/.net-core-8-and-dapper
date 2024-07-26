using System.Security.Cryptography;
using System.Text;

namespace AspNetCore.Identity.Dapper.Manager;
public class PasswordHashGenerator : IPasswordHashGenerator
{
    public string GenerateSHA1PasswordHash(string password)
    {
        byte[] hashBytes = SHA1.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashBytes);
    }
}
