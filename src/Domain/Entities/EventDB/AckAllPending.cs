using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.EventDB;

[Table("AckAllPending")]
public class AckAllPending
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime? AckTimeStamp { get; set; }
}
