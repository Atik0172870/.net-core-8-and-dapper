using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class SystemSettings
{
    [Key]
    public int SysId { get; set; }

    public int? SysBadgeLen { get; set; }

    public bool? UseAutoAck { get; set; }

    public int? AutoAckPriority { get; set; }

    public int? RespReqTz { get; set; }

    public int? TagType { get; set; }

    public int? AGCountPerBadge { get; set; }

    public bool? UseAPBAreas { get; set; }

    public bool? UseCatCounters { get; set; }

    public bool? UseFacBadge { get; set; }

    public bool? HidePinCode { get; set; }

    public bool? HideSSN { get; set; }

    public bool? UseALP { get; set; }

    public bool? UseHoliday { get; set; }

    public bool? UseNAPCO { get; set; }

    public bool? UseScripting { get; set; }

    public bool? UseVideo { get; set; }

    public DateTime? APBResetTime { get; set; }

    public int? APBResetArea { get; set; }

    public int? BadgeReIssueLevel { get; set; }

    public bool? UseNAPCOPermissions { get; set; }

    public int? UsePIV { get; set; }

    public bool? UseHostTz { get; set; }

    public bool? AutoCreateDevice { get; set; }

    public int? LockDown { get; set; }

    public int? PrintPriority { get; set; }

    public int? PrintBySchedule { get; set; }

    public bool? UseStrongPasswords { get; set; }

    public int? PasswordMinLength { get; set; }

    public int? PasswordMaxLength { get; set; }

    public int? PasswordMinNonAlphaChars { get; set; }

    [MaxLength(200)]
    public string PasswordRegEx { get; set; } = null!;

    public int? KeypadOption { get; set; }

    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid CaObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [MaxLength(50)]
    public string LastWorkStation { get; set; } = null!;

    public bool? UseLDAPAuthentication { get; set; }

    public bool? UseLDAPAuthorization { get; set; }

    public bool? UseFacilityMaps { get; set; }

    public bool? UseCustomMenu { get; set; }

    [MaxLength(255)]
    public string LDAPPath { get; set; } = null!;

    public int? UTCOffset { get; set; }

    public bool? EnforceGroups { get; set; }

    public int BroadcastValue { get; set; }

    [Required]
    public Guid APBResetPartition { get; set; }

    public int? CompanyId { get; set; }

    [MaxLength(1000)]
    public string CompanyName { get; set; } = null!;

    [MaxLength(100)]
    public string LiveConfigServer { get; set; } = null!;

    [MaxLength(100)]
    public string LiveConfigDB { get; set; } = null!;

    [MaxLength(100)]
    public string LiveEventServer { get; set; } = null!;

    [MaxLength(100)]
    public string LiveEventDB { get; set; } = null!;

    [MaxLength(100)]
    public string DatabaseUserName { get; set; } = null!;

    [MaxLength(100)]
    public string DatabasePassword { get; set; } = null!;

    [MaxLength(100)]
    public string ScriptEmailServer { get; set; } = null!;

    [MaxLength(100)]
    public string ScriptEmailFrom { get; set; } = null!;

    [MaxLength(100)]
    public string ScriptEmailPort { get; set; } = null!;

    [MaxLength(100)]
    public string ScriptEmailPassword { get; set; } = null!;

    public int CloudUserType { get; set; }

    public bool? UseCS { get; set; }

    [Required]
    [MaxLength(255)]
    public string NotificationEmailTemplate { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public string NotificationSMSTemplate { get; set; } = null!;

    public bool? ShowHexCode { get; set; }

    public int? PasswordExpireDays { get; set; }

    public bool? EnableGeoFencing { get; set; }

    [MaxLength]
    public string OktaConfiguration { get; set; } = null!;

    public int? AuthenticationType { get; set; }
}
