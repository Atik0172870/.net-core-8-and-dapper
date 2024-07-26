namespace AspNetCore.Identity.Dapper.Stores;

internal class UserLogin
{
    public string LoginProvider { get; set; } = null!;
    public string ProviderKey { get; set; } = null!;
    public string ProviderDisplayName { get; set; } = null!;
    public string UserId { get; set; } = null!;
}
