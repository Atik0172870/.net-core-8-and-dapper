using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.PortalDb;

[Table("UserMessages")]
    public class UserMessage
    {
        [Key]
        public int Id { get; set; }

        public int MessageId { get; set; }

        public long UserId { get; set; }

        [StringLength(10)]
        public string Status { get; set; } = default!;
    }
