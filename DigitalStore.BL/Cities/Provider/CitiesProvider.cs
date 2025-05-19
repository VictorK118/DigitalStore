using AutoMapper;
using DigitalStore.BL.Cities.Entities;
using DigitalStore.BL.Exceptions.CitiesExceptions;
using DigitalStore.BL.Exceptions.UsersExceptions;
using DigitalStore.DataAccess.Entities;
using DigitalStore.DataAccess.Repository;

namespace DigitalStore.BL.Cities.Provider;

public class CitiesProvider(IRepository<CitiesEntity> cityRepository, IMapper mapper) : ICitiesProvider
{
    private readonly IRepository<CitiesEntity> _citiesRepository;
    private readonly IMapper _mapper;

    public CitiesProvider(IRepository<CitiesEntity> cityRepository, IMapper mapper, 
        IRepository<CitiesEntity> citiesRepository) : this(cityRepository, mapper)
    {
        _citiesRepository = citiesRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CityModel>> GetCitiesAsync(CitiesFilterModel filter = null)
    {
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;
        string? namePart = filter?.NamePart;

        var cities = await cityRepository.GetAllAsync(c =>
            (creationTime == null || c.CreationTime == creationTime) &&
            (modificationTime == null || c.ModificationTime == modificationTime) &&
            (namePart == null || c.Name.Contains(namePart)));
        return mapper.Map<IEnumerable<CityModel>>(cities);
    }

    public async Task<CityModel> GetCityInfoAsync(Guid id)
    {
        var entity = await cityRepository.GetByIdAsync(id);
        if (entity == null)
            throw new CityNotFoundException("City not found");

        return mapper.Map<CityModel>(entity);
    }
}