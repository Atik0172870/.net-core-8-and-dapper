using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("EventResponse")]
public class EventResponse
{
    [Key]
    public Guid EventResponseID { get; set; } = Guid.NewGuid();

    [Key]
    public Guid EventSeqNo { get; set; }

    [Required]
    [Column("EventResponse")]
    public string EventResponseText { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string EventDescription { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string EventLocation { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string EventEventType { get; set; } = string.Empty;

    [Required]
    public DateTime EventEDate { get; set; }

    [Required]
    public int EventPriority { get; set; }

    [Required]
    public int EventArch { get; set; }

    [Required]
    [MaxLength(50)]
    public string Operator { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string WorkstationName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string WorkstationNumber { get; set; } = string.Empty;

    [Required]
    public DateTime EventResponseDateTime { get; set; } = DateTime.Now;
}
