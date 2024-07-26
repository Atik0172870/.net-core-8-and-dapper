using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;


[Table("AlertSounds")]
public class AlertSound
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int SoundIndex { get; set; }

    [StringLength(10)]
    public string? SoundName { get; set; }

    [Column("AlertSound")]
    public string? AlertSounds { get; set; }

    [Required]
    public Guid CaObjectId { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }
}
