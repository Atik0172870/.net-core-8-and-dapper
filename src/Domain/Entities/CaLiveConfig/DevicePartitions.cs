namespace CardAccess.Domain.Entities.CaLiveConfig;

public class DevicePartitions
{
    public Guid PartitionID { get; set; }
    public Guid caObjectID { get; set; }
    public int? dpDeviceType { get; set; }
    public int? CompanyId { get; set; }
}
