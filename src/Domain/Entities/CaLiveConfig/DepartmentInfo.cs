namespace CardAccess.Domain.Entities.CaLiveConfig;

public class DepartmentInfo
{
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; } = null!;
    public DateTime LastUpdated { get; set; }
    public int CompanyId { get; set; }
}
