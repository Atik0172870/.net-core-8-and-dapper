namespace CardAccess.Domain.Entities.CaLiveConfig;

public class DvrConfig
{
    public Guid DvrID { get; set; }
    public string ServerName { get; set; } = null!;
    public string ServerIP { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; }=null!;
    public string ConfirmPwd { get; set; } = null!;
    public int? UserType { get; set; }
    public bool Active { get; set; }
    public bool? EnableNotification { get; set; }
    public int? DVRVendor { get; set; }
    public int? ZoneID { get; set; }
    public DateTime? LastUpdated { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public int CompanyId { get; set; }
}
