using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Operator
{
    [Key]
    public Guid OperatorID { get; set; }

    public Guid? RoleID { get; set; }

    [Required]
    [MaxLength(50)]
    public string OperFName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string OperLName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string OperLoginName { get; set; }=null!;

    [Required]
    public bool Enabled { get; set; }

    [MaxLength(50)]
    public string? OperPassword { get; set; }

    [MaxLength(51)]
    public string? PhoneNo { get; set; }

    [MaxLength(40)]
    public string? EmailID { get; set; }

    [MaxLength(20)]
    public string? PagerID { get; set; }

    [Required]
    public DateTime LastLoggedIn { get; set; }

    [MaxLength(50)]
    public string? LastLoggedInUncName { get; set; }

    public int? LogoffTime { get; set; }

    public int? AutoAckTime { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public bool? PasswordRequiresUpdate { get; set; }

    [Required]
    public bool IsGlobalAdministrator { get; set; }

    public int? MaxThreatLevelAllowed { get; set; }

    public bool? CanChangeThreatLevel { get; set; }

    public bool? UseLegacyDisplay { get; set; }

    public int? ManualPrivileges { get; set; }

    public int? OperSNPPHostID { get; set; }

    public bool? OperUseSNPP { get; set; }

    public bool? OperUseEmail { get; set; }

    public int? ColorScheme { get; set; }

    public int? PasswordExpiresIn { get; set; }

    public int? LoginAttempts { get; set; }

    public bool? DisableLogoff { get; set; }

    public int? LanguageId { get; set; }

    [Required]
    public int EventCount { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    public bool? OperUseSMS { get; set; }

    public int? OperSMSHostID { get; set; }

    [MaxLength(50)]
    public string? LastPosPhoto { get; set; }

    [MaxLength(50)]
    public string? LastPosVideo { get; set; }

    [MaxLength(50)]
    public string? LastPosResp { get; set; }

    [MaxLength(50)]
    public string? LastPosMap { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public int? ParentCompanyId { get; set; }

    public int? OperType { get; set; }

    public bool? IsportalUser { get; set; }

    public bool? ShowGuide { get; set; }

    public bool? HideBusyDlg { get; set; }

    [MaxLength]
    public string? MobileAppConfig { get; set; }

    public DateTime? PasswordChangedOn { get; set; }

    [MaxLength(250)]
    public string? DefaultPage { get; set; }

    public bool? IsComnetManagedUser { get; set; }

    [MaxLength(50)]
    public string? AuthenticatorKey { get; set; }

    public bool? TwoFactorEnabled { get; set; }
}
