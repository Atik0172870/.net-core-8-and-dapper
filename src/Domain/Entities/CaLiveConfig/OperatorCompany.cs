using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class OperatorCompany
{
    [Key]
    public Guid OperatorId { get; set; }

    [Key]
    public int CompanyId { get; set; }
}
