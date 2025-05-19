using DigitalStore.BL.Mapper;
using DigitalStore.Service.Mapper;

namespace DigitalStore.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            //config.AddProfile<UsersBLProfile>();
            config.AddProfile<CitiesBLProfile>();
            config.AddProfile<CitiesServiceBrofile>();
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UsersServiceProfile>();
        });
    }
}