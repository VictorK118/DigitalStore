using AutoMapper;
using DigitalStore.BL.Auth;
using DigitalStore.BL.Cities.Managers;
using DigitalStore.BL.Cities.Provider;
using DigitalStore.BL.Users.Manager;
using DigitalStore.BL.Users.Provider;
using DigitalStore.DataAccess;
using DigitalStore.DataAccess.Entities;
using DigitalStore.DataAccess.Repository;
using DigitalStore.Repository;
using DigitalStore.Service.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitalStore.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services, DigitalStoreSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<RolesEntity>>(x =>
            new Repository<RolesEntity>(x.GetRequiredService<IDbContextFactory<DigitalStoreDbContext>>()));


        services.AddScoped<IRepository<CitiesEntity>>(x =>
            new Repository<CitiesEntity>(x.GetRequiredService<IDbContextFactory<DigitalStoreDbContext>>()));

        services.AddScoped<ICitiesProvider, CitiesProvider>(x =>
            new CitiesProvider(x.GetRequiredService<IRepository<CitiesEntity>>(),
                x.GetRequiredService<IMapper>()));
        services.AddScoped<ICitiesManager, CitiesManager>(x =>
            new CitiesManager(x.GetRequiredService<IRepository<CitiesEntity>>(),
                x.GetRequiredService<IMapper>()));

        services.AddScoped<IUsersProvider>(x => 
            new UsersProvider(x.GetRequiredService<IRepository<UsersEntity>>(), 
                x.GetRequiredService<IMapper>()));
        
        services.AddScoped<IAuthService>(x =>
            new AuthService(
                x.GetRequiredService<DigitalStoreDbContext>(),
                x.GetRequiredService<SignInManager<UsersEntity>>(),
                x.GetRequiredService<UserManager<UsersEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                x.GetRequiredService<IMapper>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));
        //     
        //     services.AddScoped<IUsersManager>(x =>
        //         new UsersManager(x.GetRequiredService<IRepository<UserEntity>>(),
        //             x.GetRequiredService<IRepository<PermissionEntity>>(),
        //             x.GetRequiredService<IMapper>()));
        //
        //     services.AddScoped<IAuthProvider>(x => new AuthProvider(
        //         x.GetRequiredService<SignInManager<UserEntity>>(),
        //         x.GetRequiredService<UserManager<UserEntity>>(),
        //         x.GetRequiredService<IHttpClientFactory>(),
        //         x.GetRequiredService<IMapper>(),
        //         settings.IdentityServerUri,
        //         settings.ClientId,
        //         settings.ClientSecret));
    }
}