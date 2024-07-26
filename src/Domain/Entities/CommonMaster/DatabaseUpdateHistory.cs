using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("DatabaseUpdateHistory")]
public class DatabaseUpdateHistory
{
    [DataType(DataType.DateTime)]
    public DateTime? LastUpdateDate { get; set; }
}
