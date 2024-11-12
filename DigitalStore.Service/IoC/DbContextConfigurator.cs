using DigitalStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using DigitalStore.Service.Settings;

namespace DigitalStore.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, DigitalStoreSettings settings)
    {
        services.AddDbContextFactory<DigitalStoreDbContext>(
            options => { options.UseNpgsql(settings.DigitalStoreDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DigitalStoreDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
    }
}