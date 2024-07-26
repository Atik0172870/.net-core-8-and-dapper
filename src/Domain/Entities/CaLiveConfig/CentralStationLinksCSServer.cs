using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class CentralStationLinksCSServer
{
    [Key]
    public Guid centralStationId { get; set; }

    [Key]
    public Guid CentralStationLinkId { get; set; }
}
