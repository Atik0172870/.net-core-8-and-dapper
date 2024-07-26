using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("AlarmLink_ScheduleType")]
public class AlarmLinkScheduleType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string TypeName { get; set; } = null!;

}
