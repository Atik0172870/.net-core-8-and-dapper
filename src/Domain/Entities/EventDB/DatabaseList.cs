using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("DatabaseList")]
public class DatabaseList
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(64)]
    public string? ServerName { get; set; }

    [MaxLength(64)]
    public string? DatabaseName { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}

