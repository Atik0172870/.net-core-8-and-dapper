namespace CardAccess.Domain.Entities.PortalDb;

public class Message
{
    public int Id { get; set; }

    public long Sender { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public DateTime SendTime { get; set; }

    public string? Receivers { get; set; }
}
