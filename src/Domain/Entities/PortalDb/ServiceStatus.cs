using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;
#nullable enable

[Table("ServiceStatus")]
    public class ServiceStatus
    {
        [StringLength(50)]
        public string? ServerIP { get; set; }

        public int? ServiceTypeId { get; set; }

        [StringLength(50)]
        public string? ServiceName { get; set; }

        public DateTime? LastExecutionUTC { get; set; }
    }

