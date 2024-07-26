using AspNetCore.Identity.Dapper.Models;
using CardAccess.Domain.Constants;
using CardAccess.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CardAccess.Infrastructure.Data;
public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await Task.CompletedTask;

        //await initialiser.InitialiseAsync();

        //await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser(
    ILogger<ApplicationDbContextInitialiser> logger,
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    RoleManager<ApplicationRole> roleManager)
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger = logger;
    private readonly ApplicationDbContext _context = context;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await Task.CompletedTask;
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new ApplicationRole()
        {
            Name = Roles.Administrator,
        };

        await Task.CompletedTask;


        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
            await _roleManager.CreateAsync(new ApplicationRole
            {
                Name = Roles.Dealer
            });
            await _roleManager.CreateAsync(new ApplicationRole
            {
                Name = Roles.Customer
            });
        }

        // Default users
        ApplicationUser administrator = new()
        {
            Id = Guid.Parse("9982ED2D-9128-466E-AF0A-F69E8FD07F93"),
            OperatorID = Guid.Parse("9982ED2D-9128-466E-AF0A-F69E8FD07F93"),
            RoleID = null,
            OperFName = "assad",
            OperLName = "assad",
            OperLoginName = "assad",
            Enabled = false,
            OperPassword = "4ShuHinEY4nSLaH/I/puFlQpEl8=",
            PhoneNo = null,
            EmailID = "assad",
            PagerID = null,
            LastLoggedIn = DateTime.Parse("2024-05-24 15:30:27.520"),
            LastLoggedInUncName = null,
            LogoffTime = null,
            AutoAckTime = null,
            LastUpdated = DateTime.Parse("2024-05-24 15:30:27.520"),
            PasswordRequiresUpdate = false,
            IsGlobalAdministrator = false,
            MaxThreatLevelAllowed = null,
            CanChangeThreatLevel = null,
            UseLegacyDisplay = null,
            ManualPrivileges = null,
            OperSNPPHostID = null,
            OperUseSNPP = null,
            OperUseEmail = null,
            ColorScheme = null,
            PasswordExpiresIn = null,
            LoginAttempts = null,
            DisableLogoff = null,
            LanguageId = null,
            EventCount = 0,
            LastOperator = null,
            LastWorkStation = null,
            UTCOffset = null,
            OperUseSMS = null,
            OperSMSHostID = null,
            LastPosPhoto = null,
            LastPosVideo = null,
            LastPosResp = null,
            LastPosMap = null,
            CompanyId = 0,
            ParentCompanyId = null,
            OperType = null,
            IsportalUser = null,
            ShowGuide = null,
            HideBusyDlg = null,
            MobileAppConfig = null,
            PasswordChangedOn = null,
            DefaultPage = null,
            IsComnetManagedUser = null,
            AuthenticatorKey = null,
            UserName = "assad",
            NormalizedUserName = "ASSAD",
            Email = "assad",
            NormalizedEmail = "ASSAD",
            EmailConfirmed = false,
            PasswordHash = "4ShuHinEY4nSLaH/I/puFlQpEl8=",
            SecurityStamp = "CQY2UQTI7OWH2JVM44RJEBIFALDM3C2Q",
            ConcurrencyStamp = "cfa8ccce-9c5a-41d2-8cd4-b5fbd4c802cf",
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0
        };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, [Roles.Dealer, Roles.Customer]);
            }
        }

        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}
