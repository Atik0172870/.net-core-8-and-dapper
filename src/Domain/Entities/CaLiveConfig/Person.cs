using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class Person
{
    [Key]
    public Guid PersonID { get; set; }

    public bool? Enabled { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(30)]
    public string? MiddleName { get; set; }

    [StringLength(1)]
    public string? Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? DeptID { get; set; }

    [StringLength(30)]
    public string? Phone { get; set; }

    public int? LocationID { get; set; }

    [StringLength(50)]
    public string? Vehicle { get; set; }

    [StringLength(20)]
    public string? License { get; set; }

    public bool? Supervisor { get; set; }

    public Guid? SupervisorID { get; set; }

    [StringLength(30)]
    public string? ContPhone { get; set; }

    [StringLength(12)]
    public string? SSN { get; set; }

    public int? CompanyID { get; set; }

    public string? Remarks { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    [StringLength(50)]
    public string? LastWorkStation { get; set; }

    [StringLength(30)]
    public string? MobileNo { get; set; }

    [StringLength(100)]
    [EmailAddress]
    public string? Email { get; set; }
}
