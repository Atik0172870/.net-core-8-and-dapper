namespace CardAccess.Domain.Entities.CaLiveConfig;

public class EpiDbConfig
{
    public int Id { get; set; }
    public int? Connect_Type { get; set; }
    public int? Valid_Config { get; set; }
    public string? Version { get; set; }
    public int? Max_Image_Blob { get; set; }
    public int CompanyId { get; set; }
}
