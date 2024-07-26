namespace CardAccess.Domain.Entities.CaLiveConfig;

public class EpiConfig
{
    public string Cfg_User { get; set; } = null!;
    public int Cfg_Level { get; set; }
    public string Cfg_Section { get; set; } = null!;
    public string Cfg_Name { get; set; } = null!;
    public string? Cfg_Value { get; set; }
}
