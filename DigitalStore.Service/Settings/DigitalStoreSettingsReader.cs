namespace DigitalStore.Service.Settings;

public class DigitalStoreSettingsReader
{
    public static DigitalStoreSettings Read(IConfiguration configuration)
    {
        return new DigitalStoreSettings()
        {
            DigitalStoreDbContextConnectionString = configuration.GetValue<string>("DigitalStoreDbContext")
        };
    }
}