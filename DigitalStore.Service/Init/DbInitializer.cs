using DigitalStore.DataAccess.Entities;
using DigitalStore.Service.Settings;
using Microsoft.AspNetCore.Identity;

namespace DigitalStore.Service.Init;

public static class DbInitializer
{
    public static async Task InitializeAsync(IApplicationBuilder app, DigitalStoreSettings settings)
    {
        using var scope = app.ApplicationServices.CreateScope();

        await AddRolesAsync(scope);
        await CreateMasterAdminAsync(scope, settings);
    }

    private static async Task AddRolesAsync(IServiceScope scope)
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
        
        var roles = new[]
        {
            "admin", 
            "user" 
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new Role { Name = role });
        }
    }

    private static async Task CreateMasterAdminAsync(IServiceScope scope, DigitalStoreSettings settings)
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UsersEntity>>();
        
        var user = await userManager.FindByEmailAsync(settings.MasterAdminEmail);
        if (user is null)
        {
            user = new UsersEntity
            {
                Email = settings.MasterAdminEmail,
                UserName = settings.MasterAdminEmail,
                Name = settings.MasterAdminEmail,
                Surname = settings.MasterAdminEmail,
                Patronymicname = settings.MasterAdminEmail,
            };
            await userManager.CreateAsync(user, settings.MasterAdminPassword);
            await userManager.AddToRoleAsync(user, "admin");
        }
    }
}