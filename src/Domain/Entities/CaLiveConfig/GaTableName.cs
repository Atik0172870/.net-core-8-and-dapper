using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaTableName
{
    [Key]
    public int Id { get; set; }

    [Column("Table_Name")]
    public string TableName { get; set; } = null!;
}
