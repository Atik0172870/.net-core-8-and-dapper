using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("Messages")]
public class Message
{
    [Key]
    public int Messagetype { get; set; }

    [Column("Message")]
    public string? MessageText { get; set; }
}
