using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardAccess.Domain.Entities.CaLiveConfig;
public class ActiveLinks
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ALPId { get; set; }

    public int PnlRef { get; set; }

    public int ProgNo { get; set; }

    public int PnlNo { get; set; }

    public int RelNo { get; set; }

    public int InpNo { get; set; }

    public int RdrNo { get; set; }

    public int CatNo { get; set; }

    public int? Control { get; set; }

    public bool? Active { get; set; }

    public int? CatReader { get; set; }

    public Guid caObjectID { get; set; }

    public Guid? LastOperator { get; set; }

    public string? LastWorkStation { get; set; }

    public int CompanyId { get; set; }
}
