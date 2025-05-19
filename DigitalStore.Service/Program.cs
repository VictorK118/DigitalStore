using DigitalStore.Service.Init;
using DigitalStore.Service.IoC;
using DigitalStore.Service.Settings;


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = DigitalStoreSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

SerilogConfigurator.ConfigureService(builder);
AuthConfigurator.ConfigureServices(builder.Services, settings);
DbContextConfigurator.ConfigureService(builder.Services, settings);
MapperConfigurator.ConfigureServices(builder.Services);
SwaggerConfigurator.ConfigureServices(builder.Services);
ServicesConfigurator.ConfigureServices(builder.Services, settings);
builder.Services.AddControllers();

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
AuthConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);
await DbInitializer.InitializeAsync(app, settings);
app.MapControllers();

app.Run();