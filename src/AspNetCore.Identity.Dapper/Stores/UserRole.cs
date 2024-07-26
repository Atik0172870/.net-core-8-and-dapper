namespace AspNetCore.Identity.Dapper.Stores;

internal class UserRole
{
    public Guid RoleId { get; set; } = default!;
    public string RoleName { get; set; } = null!;
}
