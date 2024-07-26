namespace CardAccess.Domain.Entities.CaLiveConfig;

public class DbQueryParams
{
    public string queryName { get; set; } = null!;
    public string paramName { get; set; } = null!;
    public int? paramDataType { get; set; }
    public int? paramDirection { get; set; }
}
