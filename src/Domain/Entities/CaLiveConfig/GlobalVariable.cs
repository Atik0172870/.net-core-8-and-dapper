namespace CardAccess.Domain.Entities.CaLiveConfig;

public class GlobalVariable
{
    public string VariableName { get; set; } = null!;

    public string? VariableValue { get; set; }

    public int CompanyId { get; set; }
}
