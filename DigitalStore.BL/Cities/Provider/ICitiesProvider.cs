using DigitalStore.BL.Cities.Entities;

namespace DigitalStore.BL.Cities.Provider;

public interface ICitiesProvider
{
    IEnumerable<CityModel> GetCities(CitiesFilterModel filter = null);
    CityModel GetCityInfo(int id);
}