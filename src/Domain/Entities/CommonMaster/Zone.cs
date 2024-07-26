using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("Zones")]
public class Zone
{
    [Key]
    [Column("ZoneId")]
    public int ZoneId { get; set; }

    [Required]
    [Column("Description")]
    [StringLength(75)]
    public string Description { get; set; } = null!;

    [Required]
    [Column("StandardName")]
    [StringLength(100)]
    public string StandardName { get; set; } = null!;

    [Column("UTCBias")]
    public long UTCBias { get; set; }

    [Column("sBias")]
    public long SBias { get; set; }

    [Column("sMonth")]
    public short SMonth { get; set; }

    [Column("sDay")]
    public short SDay { get; set; }

    [Column("sHour")]
    public short SHour { get; set; }

    [Column("sMinute")]
    public short SMinute { get; set; }

    [Column("sSecond")]
    public short SSecond { get; set; }

    [Column("dBias")]
    public long DBias { get; set; }

    [Column("dMonth")]
    public short DMonth { get; set; }

    [Column("dDay")]
    public short DDay { get; set; }

    [Column("dHour")]
    public short DHour { get; set; }

    [Column("dMinute")]
    public short DMinute { get; set; }

    [Column("dSecond")]
    public short DSecond { get; set; }

    [NotMapped]
    public DateTime DStart => ca_fn_AssembleDate(DMonth, DDay, DHour, DMinute, DSecond, DateTime.Now);

    [NotMapped]
    public DateTime SStart => ca_fn_AssembleDate(SMonth, SDay, SHour, SMinute, SSecond, DateTime.Now);

    private DateTime ca_fn_AssembleDate(short month, short day, short hour, short minute, short second, DateTime currentDate)
    {
        return new DateTime(currentDate.Year, month, day, hour, minute, second);
    }
}
