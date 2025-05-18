using AutoMapper;
using DigitalStore.BL.Cities.Entities;
using DigitalStore.BL.Exceptions.UsersExceptions;
using DigitalStore.DataAccess.Entities;
using DigitalStore.DataAccess.Repository;

namespace DigitalStore.BL.Cities.Provider;

public class CitiesProvider(IRepository<CitiesEntity> cityRepository, IMapper mapper) : ICitiesProvider
{
    public IEnumerable<CityModel> GetCities(CitiesFilterModel filter = null)
    {
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;
        string? namePart = filter?.NamePart;

        var cities = cityRepository.GetAll(c =>
            (creationTime == null || c.CreationTime == creationTime) &&
            (modificationTime == null || c.ModificationTime == modificationTime) &&
            (namePart == null || c.Name.Contains(namePart)));
        return mapper.Map<IEnumerable<CityModel>>(cities);
    }

    public CityModel GetCityInfo(int id)
    {
        var entity = cityRepository.GetById(id);
        if (entity == null)
            throw new RoleNotFoundException("Role not found");

        return mapper.Map<CityModel>(entity);
    }
}