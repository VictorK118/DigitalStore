using System.Text;
using AutoMapper;
using DigitalStore.BL.Cities.Entities;
using DigitalStore.BL.Cities.Managers;
using DigitalStore.BL.Cities.Provider;
using DigitalStore.BL.Exceptions.CitiesExceptions;
using DigitalStore.Service.Controllers.Cities.Entities;
using DigitalStore.Service.Validator.Cities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalStore.Service.Controllers.Cities;

[ApiController]
[Route("[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICitiesProvider _citiesProvider;
    private readonly ICitiesManager _citiesManager;
    private readonly ILogger<CitiesController> _logger;
    private readonly IMapper _mapper;

    public CitiesController(ICitiesProvider citiesProvider, ICitiesManager citiesManager, ILogger<CitiesController> logger, IMapper mapper)
    {
        _citiesProvider = citiesProvider;
        _citiesManager = citiesManager;
        _logger = logger;
        _mapper = mapper;
    }
    
    [Authorize(Roles = "admin")]
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateCity([FromBody] CreateCityRequest request)
    {
        var validationResult = await new CreateCityRequestValidator().ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage);
            var stringBuilder = new StringBuilder();
            foreach (var error in errors)
            {
                stringBuilder.AppendLine(error);
            }
            _logger.LogError(stringBuilder.ToString());
            return BadRequest(errors);
        }
        
        var createModel = _mapper.Map<CreateCityModel>(request);
        try
        {
            var cityModel = await _citiesManager.CreateCityAsync(createModel);
            return Ok(new CitiesResponse([cityModel]));
        }
        catch (CityAlreadyExistsException e)
        {
            _logger.LogError(e.Message);
            return Conflict(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllCities()
    {
        var cities = await _citiesProvider.GetCitiesAsync();
        return Ok(new CitiesResponse(cities.ToList()));
    }
    
    [HttpGet]
    [Route("filtered")]
    public async Task<IActionResult> GetAllCities([FromQuery] CitiesFilter filter)
    {
        var filterModel = _mapper.Map<CitiesFilterModel>(filter);
        var cities = await _citiesProvider.GetCitiesAsync(filterModel);
        return Ok(new CitiesResponse(cities.ToList()));
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCityById([FromRoute] Guid id)
    {
        try
        {
            var city = await _citiesProvider.GetCityInfoAsync(id);
            return Ok(new CitiesResponse([city]));
        }
        catch (CityNotFoundException e)
        {
            _logger.LogError(e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpGet]
    [Route("{id:guid}/delete")]
    public async Task<IActionResult> DeleteCity([FromRoute] Guid id)
    {
        try
        {
            await _citiesManager.DeleteCityAsync(id);
            return Ok("City deleted successfully");
        }
        catch (CityNotFoundException e)
        {
            _logger.LogError(e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
    
    [Authorize(Roles = "admin")]
    [HttpPost]
    [Route("{id:guid}/update")]
    public async Task<IActionResult> UpdateCity([FromRoute] Guid id, [FromBody] UpdateCityRequest request)
    {
        var validationResult = await new UpdateCityRequestValidator().ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage);
            var stringBuilder = new StringBuilder();
            foreach (var error in errors)
            {
                stringBuilder.AppendLine(error);
            }
            _logger.LogError(stringBuilder.ToString());
            return BadRequest(errors);
        }
        
        var updateModel = _mapper.Map<UpdateCityModel>(request);
        try
        {
            var cityModel = await _citiesManager.UpdateCityAsync(updateModel, id);
            return Ok(new CitiesResponse([cityModel]));
        }
        catch (CityAlreadyExistsException e)
        {
            _logger.LogError(e.Message);
            return Conflict(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
}