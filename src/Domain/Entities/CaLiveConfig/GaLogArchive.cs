using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaLogArchive
{
    [Key]
    [Column("Log_ID")]
    public string LogId { get; set; } = null!;

    [Column("Operator_ID")]
    public string OperatorId { get; set; } = null!;

    [Column("Station_ID")]
    public string StationId { get; set; } = null!;

    [Column("Log_Date")]
    public DateTime LogDate { get; set; }

    [Column("Event")]
    public string Event { get; set; } = null!;

    [Column("Person_ID")]
    public string? PersonId { get; set; }

    [Column("Card_ID")]
    public string? CardId { get; set; }

    [Column("Card_Code")]
    public string? CardCode { get; set; }

    [Column("Info1")]
    public string? Info1 { get; set; }

    [Column("Info2")]
    public string? Info2 { get; set; }

    [Column("Info3")]
    public string? Info3 { get; set; }

    [Column("Info4")]
    public string? Info4 { get; set; }
}
