namespace AspNetCore.Identity.Dapper.Stores;
internal class UserClaim
{
    public string Id { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string ClaimType { get; set; } = null!;
    public string ClaimValue { get; set; } = null!;
}
