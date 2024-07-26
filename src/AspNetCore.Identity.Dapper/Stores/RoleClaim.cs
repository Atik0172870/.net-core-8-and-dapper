namespace AspNetCore.Identity.Dapper.Stores;
internal class RoleClaim
{
    public string Id { get; set; } = null!;
    public string RoleId { get; set; } = null!;
    public string ClaimType { get; set; } = null!;
    public string ClaimValue { get; set; } = null!;
}
