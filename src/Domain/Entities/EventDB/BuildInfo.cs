using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("BuildInfo")]
public class BuildInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required]
    public int BuildNumber { get; set; }

    [Required]
    public DateTime LastChanged { get; set; } = DateTime.UtcNow;
}
