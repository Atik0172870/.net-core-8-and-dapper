using System.ComponentModel.DataAnnotations;

namespace CardAccess.Domain.Entities.CaLiveConfig;

public class EpiFile
{
    [Key]
    public Guid TemplateFileID { get; set; }

    public byte[]? TemplateFileData { get; set; }

    public int CompanyId { get; set; }
}
