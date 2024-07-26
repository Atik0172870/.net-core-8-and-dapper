using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class NapcoPanels
{
    [Key]
    public int AlarmPanelID { get; set; }

    public int? WorkstationID { get; set; }

    [Required]
    public int PanelType { get; set; }

    [MaxLength(50)]
    public string? PanelName { get; set; }

    [Required]
    public int ConnectionType { get; set; }

    [Required]
    public int PortNumber { get; set; }

    [MaxLength(50)]
    public string? SocketAddress { get; set; }

    [Required]
    [MaxLength(6)]
    public string MasterProgramCode { get; set; } = string.Empty;

    [Required]
    public bool Enabled { get; set; }

    public int? PCSecurityCode1 { get; set; }

    public int? PCSecurityCode2 { get; set; }

    public int? PCSecurityCode3 { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }

    public int? ZoneId { get; set; }

    public int? MapId { get; set; }

    [Key]
    public int CompanyId { get; set; }
}
