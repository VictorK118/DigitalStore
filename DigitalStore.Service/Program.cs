using DigitalStore.Service.IoC;
using DigitalStore.Service.Settings;


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = DigitalStoreSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

SerilogConfigurator.ConfigureService(builder);
DbContextConfigurator.ConfigureService(builder.Services, settings);
MapperConfigurator.ConfigureServices(builder.Services);
SwaggerConfigurator.ConfigureServices(builder.Services);

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);

app.MapControllers();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();