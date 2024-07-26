using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class UserFields
{
    [Key]
    public Guid PersonID { get; set; }
    public long Badge { get; set; }
    public int Facility { get; set; }
    public int UserFieldID { get; set; }
    public string UserFieldValue { get; set; } = null!;
    public DateTime LastUpdated { get; set; }
    public Guid caObjectID { get; set; }
    public Guid? LastOperator { get; set; }
    public string LastWorkStation { get; set; } = null!;
    public int CompanyId { get; set; }
}
