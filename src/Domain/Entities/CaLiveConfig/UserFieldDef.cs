using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class UserFieldDef
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserFieldID { get; set; }

    public int? UserFieldTabId { get; set; }
    [Required]
    [MaxLength(50)]
    public string UserFieldName { get; set; } = null!;
    [MaxLength(16)]
    public string UserFieldType { get; set; } = null!;
    public int? UserFieldLength { get; set; }
    public DateTime LastUpdated { get; set; }
    public Guid caObjectId { get; set; }
    public Guid? LastOperator { get; set; }
    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;
    public int CompanyId { get; set; }
    [MaxLength(50)]
    public string UserFieldDescription { get; set; } = null!;
}
