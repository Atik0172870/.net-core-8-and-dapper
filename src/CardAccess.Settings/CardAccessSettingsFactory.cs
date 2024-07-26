namespace CardAccess.Settings;

public interface ICardAccessSettingsFactory
{
    ICardAccessSettings Create();
}
public class CardAccessSettingsFactory : ICardAccessSettingsFactory
{
    public ICardAccessSettings Create()
    {
        CardAccessSettings cardAccessSettings = new();
        cardAccessSettings.LoadEsfFile();
        return cardAccessSettings;
    }
}
