using AspNetCore.Identity.Dapper.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AspNetCore.Identity.Dapper.Manager;
public class CustomPasswordHasher : PasswordHasher<ApplicationUser>
{
    private readonly IPasswordHashGenerator _passwordHashGenerator;

    public CustomPasswordHasher(IPasswordHashGenerator passwordHashGenerator) : base() =>
        _passwordHashGenerator = passwordHashGenerator;

    public CustomPasswordHasher(
        IPasswordHashGenerator passwordHashGenerator,
        IOptions<PasswordHasherOptions>? optionsAccessor = null
        ) : base(optionsAccessor) =>
        _passwordHashGenerator = passwordHashGenerator;

    public override string HashPassword(ApplicationUser user, string password) =>
        _passwordHashGenerator.GenerateSHA1PasswordHash(password);

    public override PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword) =>
        _passwordHashGenerator.GenerateSHA1PasswordHash(providedPassword) == hashedPassword ?
            PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
}
