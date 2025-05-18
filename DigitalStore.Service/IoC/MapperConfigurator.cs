using DigitalStore.BL.Mapper;

namespace DigitalStore.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<RolesBLProfile>();
            config.AddProfile<CitiesBLProfile>();
        });
    }
}