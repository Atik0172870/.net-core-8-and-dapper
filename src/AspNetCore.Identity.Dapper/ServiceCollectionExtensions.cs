using AspNetCore.Identity.Dapper.Manager;
using AspNetCore.Identity.Dapper.Models;
using AspNetCore.Identity.Dapper.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspNetCore.Identity.Dapper;

/// <summary>
/// Extension methods on <see cref="IdentityBuilder"/> class.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds a Dapper implementation of ASP.NET Core Identity stores.
    /// </summary>
    /// <param name="builder">Helper functions for configuring identity services.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance this method extends.</returns>
    public static IdentityBuilder AddDapperStores(this IdentityBuilder builder,
        Action<DBProviderOptions> dbProviderOptionsAction = null!)
    {
        AddStores(builder.Services, builder.UserType, builder.RoleType!);
        var options = GetDefaultOptions();
        dbProviderOptionsAction?.Invoke(options);
        builder.Services.AddSingleton(options);
        builder.Services.AddScoped<IDatabaseConnectionFactory>(service =>
        new DefaultSqlConnectionFactory(options.ConnectionString, options.DbSchema));
        builder.Services.AddTransient<IPasswordHashGenerator, PasswordHashGenerator>();
        builder.Services.AddTransient<IPasswordHasher<ApplicationUser>, CustomPasswordHasher>();

        return builder;
    }

    private static void AddStores(IServiceCollection services, Type userType, Type roleType)
    {
        if (userType != typeof(ApplicationUser))
        {
            throw new InvalidOperationException($"{nameof(AddDapperStores)} can only be called with a user that is of type {nameof(ApplicationUser)}.");
        }

        if (roleType != null)
        {
            if (roleType != typeof(ApplicationRole))
            {
                throw new InvalidOperationException($"{nameof(AddDapperStores)} can only be called with a role that is of type {nameof(ApplicationRole)}.");
            }

            services.TryAddScoped<IUserStore<ApplicationUser>, UserStore>();
            services.TryAddScoped<IRoleStore<ApplicationRole>, RoleStore>();
        }

        services.AddScoped<UserManager<ApplicationUser>, CustomUserManager>();
    }

    public static DBProviderOptions GetDefaultOptions()
    {
        return new DBProviderOptions();
    }
}
