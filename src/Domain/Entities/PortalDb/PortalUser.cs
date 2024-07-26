using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("PortalUser")]
public class PortalUser
{
    [Key]
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }

    public long? ParentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? UserType { get; set; } = 1;

    public bool? SuperAdmin { get; set; } = false;

    public int? UserState { get; set; }

    [Required]
    public int ConfigSystemSettingId { get; set; }

    public string? Department { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    public string? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    public int? UTCOffset { get; set; }

    public string? CompanyName { get; set; }

    public string? CicAccountNo { get; set; }

    public int? HostingFeeId { get; set; }

    public decimal? VolumeDiscount { get; set; }

    public decimal? OptionalPremiumFeatureFee { get; set; }

    public string? CardAccessLoginAccount { get; set; }

    [Required]
    public int CloudUserType { get; set; } = -1;

    public Guid? RoleTemplateId { get; set; }

    public string? DealerId { get; set; }

    public string? SubscriberID { get; set; }

    [Required]
    public int EventLimit { get; set; } = 5000;
}
