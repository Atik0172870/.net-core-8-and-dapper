using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CommonMaster;

public class HelpLink
{
    [Required]
    [StringLength(200)]
    public string Page { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string ScreenName { get; set; } = null!;

    [Required]
    [StringLength(200)]
    public string Link { get; set; } = null!;
}
