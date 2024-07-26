using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaForeignKey
{
    [Key]
    [Column("FK_Table_Name")]
    [StringLength(254)]
    public string FkTableName { get; set; } = null!;

    [Key]
    [Column("FK_Order")]
    public int FkOrder { get; set; }

    [Key]
    [Column("PMK_Table_Name")]
    [StringLength(254)]
    public string PmkTableName { get; set; } = null!;

    [Required]
    [Column("FK_Field_Name")]
    [StringLength(254)]
    public string FkFieldName { get; set; } = null!;

    [Required]
    [Column("PMK_Field_Name")]
    [StringLength(254)]
    public string PmkFieldName { get; set; } = null!;
}
