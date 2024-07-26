using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaListData
{
    [Key]
    [Column("List_ID")]
    public string ListId { get; set; } = null!;

    [Key]
    [Column("List_Index")]
    public string ListIndex { get; set; } = null!;

    [Column("List_Text")]
    public string? ListText { get; set; }
}
