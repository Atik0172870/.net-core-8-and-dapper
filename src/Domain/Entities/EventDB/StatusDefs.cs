using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("StatusDefs")]
public class StatusDefs
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StatusID { get; set; }

    [StringLength(150)]
    public string StatusDescription { get; set; } = null!;

    public int? StatusType { get; set; }

    public int? StatusCode { get; set; }

    public DateTime? LastUpdated { get; set; }
}
