using DigitalStore.BL.Cities.Entities;

namespace DigitalStore.BL.Cities.Provider;

public interface ICitiesProvider
{
    Task<IEnumerable<CityModel>> GetCitiesAsync(CitiesFilterModel filter = null);
    Task<CityModel> GetCityInfoAsync(Guid id);
}