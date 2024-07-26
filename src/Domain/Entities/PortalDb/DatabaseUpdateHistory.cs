using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("DatabaseUpdateHistory")]
public class DatabaseUpdateHistory
{
    public DateTime? LastUpdateDate { get; set; }
}
