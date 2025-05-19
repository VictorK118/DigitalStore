using AutoMapper;
using DigitalStore.BL.Cities.Entities;
using DigitalStore.BL.Exceptions.CitiesExceptions;
using DigitalStore.DataAccess.Entities;
using DigitalStore.DataAccess.Repository;

namespace DigitalStore.BL.Cities.Managers;

public class CitiesManager : ICitiesManager
{
    private readonly IRepository<CitiesEntity> _citiesRepository;
    private readonly IMapper _mapper;

    public CitiesManager(IRepository<CitiesEntity> citiesRepository, IMapper mapper)
    {
        _citiesRepository = citiesRepository;
        _mapper = mapper;
    }

    public async Task<CityModel> CreateCityAsync(CreateCityModel model)
    {
        var entity = _mapper.Map<CitiesEntity>(model);
        try
        {
            entity = await _citiesRepository.SaveAsync(entity);
            return _mapper.Map<CityModel>(entity);
        }
        catch (CityAlreadyExistsException)
        {
            throw new CityAlreadyExistsException("City already exists");
        }
    }

    public async Task<CityModel> UpdateCityAsync(UpdateCityModel model, Guid id)
    {
        var entity = await _citiesRepository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new CityNotFoundException("City not found");
        }
        
        entity.Name = model.Name ?? entity.Name;
        
        try
        {
            entity = await _citiesRepository.SaveAsync(entity);
            return _mapper.Map<CityModel>(entity);
        }
        catch (Exception)
        {
            throw new CityAlreadyExistsException("City already exists");
        }
    }

    public async Task DeleteCityAsync(Guid id)
    {
        var entity = await _citiesRepository.GetByIdAsync(id);
        if (entity == null)
        {
            throw new CityNotFoundException("City not found");
        }
        
        await _citiesRepository.DeleteAsync(entity);
    }
}