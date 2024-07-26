namespace CardAccess.Domain.Entities.CaLiveConfig;

public class EpiFormat
{
    public string Format_ID { get; set; } = null!;
    public string Format_Name { get; set; } = null!;
    public string? Format_Range_High { get; set; }
    public string? Format_Range_Next { get; set; }
    public string? Format_Range_Field { get; set; }
    public int? Format_Range_Type { get; set; }
    public string? Format_Layout { get; set; }
    public Guid? templateFileID { get; set; }
    public int CompanyId { get; set; }
}
