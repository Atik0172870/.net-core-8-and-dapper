using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("CustomerMCom")]
public class CustomerMCom
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? PortalUserId { get; set; }

    public int? ConfigMComServerId { get; set; }
}
