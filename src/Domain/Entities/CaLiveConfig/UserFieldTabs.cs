using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class UserFieldTabs
{
    [Key]
    public int UserFieldTabID { get; set; }
    public string UserFieldTabName { get; set; } = null!;
    public DateTime? LastUpdated { get; set; }
    public Guid? caObjectId { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public int CompanyId { get; set; }
}
