using System.Security.Claims;
using System.Text;
using DigitalStore.DataAccess;
using DigitalStore.DataAccess.Entities;
using DigitalStore.Service.Init;
using DigitalStore.Service.Settings;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DigitalStore.Service.IoC;

public static class AuthConfigurator
{
    public static void ConfigureServices(IServiceCollection services, DigitalStoreSettings settings)
    {
        IdentityModelEventSource.ShowPII = true;
        
        services.AddIdentity<UsersEntity, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DigitalStoreDbContext>()
            .AddDefaultTokenProviders()
            .AddRoles<Role>(); 

        services.AddIdentityServer(options =>
            {
                
            })
            .AddInMemoryIdentityResources(IdentityServerConfigSettings.IdentityResources)
            .AddInMemoryApiScopes(IdentityServerConfigSettings.ApiScopes)
            .AddInMemoryApiResources(IdentityServerConfigSettings.ApiResources)
            .AddInMemoryClients(IdentityServerConfigSettings.GetClients(settings))
            .AddAspNetIdentity<UsersEntity>()
            .AddDeveloperSigningCredential();

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.Authority = settings.IdentityServerUri;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = true, 
                    ValidateAudience = true, 
                    ValidIssuer = settings.IdentityServerUri,
                    ValidAudience = "api",
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5),
                    RoleClaimType = ClaimTypes.Role
                };
            });
        services.AddAuthorization();

        services.AddTransient<IProfileService, IdentityProfileService>();
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}