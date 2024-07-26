using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaList
{
    [Key]
    [Column("List_ID")]
    public string ListId { get; set; } = null!;

    [Required]
    [Column("Data_Table")]
    public string DataTable { get; set; } = null!;

    [Required]
    [Column("Data_Column")]
    public string DataColumn { get; set; } = null!;

    [Required]
    [Column("List_Type")]
    public string ListType { get; set; } = null!;

    [Column("List_Table")]
    public string? ListTable { get; set; }

    [Column("List_Column")]
    public string? ListColumn { get; set; }

    [Column("Auto_Sort")]
    public string? AutoSort { get; set; }
}
