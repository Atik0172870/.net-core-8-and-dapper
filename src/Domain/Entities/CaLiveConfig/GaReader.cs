using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GaReader
{
    [Key]
    [Column("Rdr_ID")]
    public string RdrID { get; set; } = null!;

    [Column("Rdr_Name")]
    public string RdrName { get; set; } = null!;

    [Column("Rdr_Init_String")]
    public string? RdrInitString { get; set; }

    [Column("Rdr_Ack_String")]
    public string? RdrAckString { get; set; }

    [Column("Rdr_Default_Com")]
    public string? RdrDefaultCom { get; set; }

    [Column("Rdr_Has_Start_Char")]
    public string? RdrHasStartChar { get; set; }

    [Column("Rdr_Start_Char")]
    public string? RdrStartChar { get; set; }

    [Column("Rdr_Data_Timeout")]
    public string? RdrDataTimeout { get; set; }

    [Column("Rdr_Data_Max_Size")]
    public string? RdrDataMaxSize { get; set; }

    [Column("Rdr_Has_End_Char")]
    public string? RdrHasEndChar { get; set; }

    [Column("Rdr_End_Char")]
    public string? RdrEndChar { get; set; }

    [Column("Rdr_Decoder")]
    public string? RdrDecoder { get; set; }

    [Column("Rdr_Options")]
    public string? RdrOptions { get; set; }
}
