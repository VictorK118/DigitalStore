﻿using Duende.IdentityModel;
using Duende.IdentityServer.Models;

namespace DigitalStore.Service.Settings;

public static class IdentityServerConfigSettings
{
    public static IEnumerable<IdentityResource> IdentityResources =>
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource(
            name: "roles",
            displayName: "Roles",
            userClaims: [JwtClaimTypes.Role])
    ];
    
    public static IEnumerable<ApiResource> ApiResources =>
    [
        new ApiResource("api", "DigitalStore API") 
        {
            Scopes = ["api"] 
        }
    ];
    
    public static IEnumerable<ApiScope> ApiScopes => [new ApiScope("api", "DigitalStore API")];

    public static IEnumerable<Client> GetClients(DigitalStoreSettings settings) =>
    [
        new Client
        {
            ClientName = settings.ClientId,
            ClientId = settings.ClientId,
            Enabled = true,
            AllowOfflineAccess = true,
            AllowedGrantTypes =
            [
                GrantType.ClientCredentials,
                GrantType.ResourceOwnerPassword
            ],
            ClientSecrets = [new Secret(settings.ClientSecret.Sha256())],
            AllowedScopes = ["api", "offline_access", "openid", "profile", "roles"]
        },
        new Client
        {
            ClientId = "swagger",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = [new Secret("swagger".Sha256())],
            AllowedScopes = ["api", "openid", "profile", "roles"]
            
        }
    ];
}