using AspNetCore.Identity.Dapper.Models;
using CardAccess.Application.Common.Interfaces;
using CardAccess.Application.Personnel.Interface;
using CardAccess.Application.Personnel.Repository;
using CardAccess.Domain.Constants;
using CardAccess.Domain.Repositories;
using CardAccess.Domain.Repositories.Dapper;
using CardAccess.Infrastructure.Data;
using CardAccess.Infrastructure.Data.Dapper;
using CardAccess.Infrastructure.Data.Interceptors;
using CardAccess.Infrastructure.Identity;
using CardAccess.Infrastructure.Interfaces;
using CardAccess.Infrastructure.Repositories;
using CardAccess.Infrastructure.Repositories.Dapper;
using CardAccess.Infrastructure.Services;
using CardAccess.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using AspNetCore.Identity.Dapper;
using MVP.Infrastructure.Helpers;

namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        //Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddControllers();
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("CardAccess.Server"));
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitialiser>();
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<IDefaultDbConnectionFactory, DefaultDbConnectionFactory>();

        services
            .AddDefaultIdentity<ApplicationUser>(options => {
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddRoles<ApplicationRole>()
            //.AddEntityFrameworkStores<ApplicationDbContext>();
            .AddDapperStores(options =>
            {
                options.ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=CardAccessDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            });

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorizationBuilder()
            .AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator));

        services.AddCardAccessSettings();
        services.AddScoped<IConnectionStringHelper, ConnectionStringHelper>();
        services.AddScoped(typeof(IDapperDbConnection<>), typeof(DapperContext<>));
        services.AddScoped(typeof(IRepositoty<>), typeof(Repository<>));
        services.AddScoped<IPersonnel, Personnel>();

        return services;
    }
}
