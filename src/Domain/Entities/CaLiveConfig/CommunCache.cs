using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class CommunCache
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UNCName { get; set; } = null!;

    [Required]
    public int HCSNo { get; set; }

    [Required]
    public int PnlNo { get; set; }

    [Required]
    public int Operation { get; set; }

    [Required]
    public bool IsDelete { get; set; }

    [Required]
    public bool SendToAllPanels { get; set; }

    public int? Key1 { get; set; }

    public int? Key2 { get; set; }

    public int? Key3 { get; set; }

    public long? Key4 { get; set; }

    public int? Key5 { get; set; }

    public DateTime? TimeStamp { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
