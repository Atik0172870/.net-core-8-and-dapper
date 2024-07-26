using Microsoft.Extensions.DependencyInjection;

namespace MVP.Settings;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCardAccessSettings(this IServiceCollection services)
    {
        services.AddSingleton<ICardAccessSettingsFactory, CardAccessSettingsFactory>();
        services.AddSingleton(provider =>
        {
            var factory = provider.GetService<ICardAccessSettingsFactory>();
            return factory.Create();
        });

        return services;
    }
}
