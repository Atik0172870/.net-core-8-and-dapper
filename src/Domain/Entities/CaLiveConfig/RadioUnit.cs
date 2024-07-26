using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class RadioUnit
{
    [Required]
    [StringLength(20)]
    public string NocIccid { get; set; } = null!;

    [StringLength(500)]
    public string? AddressLine1 { get; set; }

    [StringLength(500)]
    public string? AddressLine2 { get; set; }

    public int? BillingStatus { get; set; }

    [StringLength(5)]
    public string? BillingType { get; set; }

    public int? CategoryType { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(1000)]
    public string? CompanyName { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }

    [StringLength(10)]
    public string? CreateDate { get; set; }

    [StringLength(10)]
    public string? CreateTime { get; set; }

    [StringLength(50)]
    public string? CsAccountNumber { get; set; }

    [StringLength(50)]
    public string? CsUserFieldA { get; set; }

    [StringLength(50)]
    public string? CsUserFieldB { get; set; }

    [StringLength(50)]
    public string? DdeId { get; set; }

    [StringLength(100)]
    public string? DealerId { get; set; }

    [StringLength(50)]
    public string? DeviceGroupId { get; set; }

    [StringLength(50)]
    public string? DigitalId { get; set; }

    [StringLength(40)]
    public string? Email { get; set; }

    [StringLength(40)]
    public string? Fax { get; set; }

    [StringLength(10)]
    public string? FeaturecreateDate { get; set; }

    [StringLength(10)]
    public string? FeaturecreateTime { get; set; }

    public int? FeatureFreeQty { get; set; }

    [StringLength(20)]
    public string? FeatureItem { get; set; }

    public int? FeatureQty { get; set; }

    [StringLength(5)]
    public string? FeatureStatus { get; set; }

    [StringLength(10)]
    public string? FeatureunitId { get; set; }

    [StringLength(10)]
    public string? FeatureupdateDate { get; set; }

    [StringLength(10)]
    public string? FeatureupdateTime { get; set; }

    [StringLength(100)]
    public string? FirstName { get; set; }

    [StringLength(5)]
    public string? FirstNet { get; set; }

    [StringLength(100)]
    public string? LastName { get; set; }

    [StringLength(50)]
    public string? ModelNumber { get; set; }

    [StringLength(50)]
    public string? NapcoSubscriberID { get; set; }

    [StringLength(10)]
    public string? NextInvocieDate { get; set; }

    [StringLength(10)]
    public string? NocCarrier { get; set; }

    [StringLength(30)]
    public string? NocComModel { get; set; }

    [StringLength(10)]
    public string? NocProdDte { get; set; }

    [StringLength(10)]
    public string? NocProdTim { get; set; }

    [StringLength(10)]
    public string? OnLineDate { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(10)]
    public string? PostalCode { get; set; }

    [StringLength(50)]
    public string? PreviousDealer { get; set; }

    [StringLength(50)]
    public string? ResellerId { get; set; }

    public int? ServiceFreeQty { get; set; }

    [StringLength(15)]
    public string? ServiceItem { get; set; }

    public int? ServiceQty { get; set; }

    [StringLength(50)]
    public string? SimId { get; set; }

    [StringLength(5)]
    public string? State { get; set; }

    [StringLength(100)]
    public string? SubscriberID { get; set; }

    [StringLength(10)]
    public string? UnitId { get; set; }

    [StringLength(5)]
    public string? UnitStatus { get; set; }

    [StringLength(10)]
    public string? UpdateDate { get; set; }

    [StringLength(10)]
    public string? UpdateTime { get; set; }

    [StringLength(100)]
    public string? UserId { get; set; }

    [StringLength(10)]
    public string? Usertype { get; set; }
}
