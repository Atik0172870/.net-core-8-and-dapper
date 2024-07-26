namespace AspNetCore.Identity.Dapper.Stores;
internal class UserToken
{
    public Guid UserId { get; set; } = default!;
    public string LoginProvider { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Value { get; set; } = null!;
}
