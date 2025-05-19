namespace DigitalStore.Service.Settings;

public class DigitalStoreSettingsReader
{
    public static DigitalStoreSettings Read(IConfiguration configuration)
    {
        return new DigitalStoreSettings()
        {
            DigitalStoreDbContextConnectionString = configuration.GetValue<string>("DigitalStoreDbContext"),
            IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
            ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
            ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            MasterAdminEmail = configuration.GetValue<string>("IdentityServerSettings:MasterAdminEmail"),
            MasterAdminPassword = configuration.GetValue<string>("IdentityServerSettings:MasterAdminPassword")
        };
    }
}