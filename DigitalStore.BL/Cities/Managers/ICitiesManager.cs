using DigitalStore.BL.Cities.Entities;

namespace DigitalStore.BL.Cities.Managers;

public interface ICitiesManager
{
    Task<CityModel> CreateCityAsync(CreateCityModel model);
    Task<CityModel> UpdateCityAsync(UpdateCityModel model, Guid id);
    Task DeleteCityAsync(Guid id);
}