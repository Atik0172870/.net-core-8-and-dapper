using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CommonMaster;

[Table("HostingServerConfig")]
public class HostingServerConfig
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("ServerName")]
    [StringLength(200)]
    public string ServerName { get; set; } = null!;

    [Column("ServerType")]
    public int? ServerType { get; set; }

    [Column("ServerIPAddress")]
    [StringLength(15)]
    public string ServerIPAddress { get; set; } = null!;

    [Column("ConfigurationMetaData")]
    public string ConfigurationMetaData { get; set; } = null!;

    [Column("ConfigurationMetaDataType")]
    [StringLength(1000)]
    public string ConfigurationMetaDataType { get; set; } = null!;

    [Column("LoadBalancerIPAddress")]
    [StringLength(20)]
    public string LoadBalancerIPAddress { get; set; } = null!;

    [Column("HealthCheckServerIPAdress")]
    [StringLength(20)]
    public string HealthCheckServerIPAddress { get; set; } = null!;

    [ForeignKey("ServerType")]
    public virtual HostingServerType HostingServerType { get; set; } = null!;
}
