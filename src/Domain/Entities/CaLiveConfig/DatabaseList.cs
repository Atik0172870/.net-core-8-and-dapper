using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class DatabaseList
{
    [Key]
    public int ID { get; set; }

    [Required]
    public string ServerName { get; set; } = null!;

    [Required]
    public string DatabaseName { get; set; } = null!;

    [Required]
    public int HcsNo { get; set; }

    [Required]
    public int DatabaseType { get; set; }

    [Required]
    public DateTime DateFrom { get; set; }

    [Required]
    public DateTime DateTo { get; set; }
}
