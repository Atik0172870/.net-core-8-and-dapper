using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.EventDB;

[Table("DatabaseUpdateHistory")]
public class DatabaseUpdateHistory
{
    public DateTime? LastUpdateDate { get; set; }
}
