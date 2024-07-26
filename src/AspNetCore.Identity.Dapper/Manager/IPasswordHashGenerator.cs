namespace AspNetCore.Identity.Dapper.Manager;

public interface IPasswordHashGenerator
{
    string GenerateSHA1PasswordHash(string password);
}