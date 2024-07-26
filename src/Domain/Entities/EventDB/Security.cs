using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.EventDB;

[Table("Security")]
public class Security
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SecID { get; set; }

    [Required]
    public int SecurityValue { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }
}
