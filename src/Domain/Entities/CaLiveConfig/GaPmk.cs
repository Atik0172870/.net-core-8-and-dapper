using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaPmk
{
    [Key]
    [Column("Table_Name")]
    public string TableName { get; set; } = null!;

    [Key]
    [Column("Key_Order")]
    public int KeyOrder { get; set; }

    [Key]
    [Column("Field_Name")]
    public string FieldName { get; set; } = null!;
}
