using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("tmpAckEvents")]
public class TmpAckEvents
{
    [Key]
    public Guid Seqno { get; set; }
}
