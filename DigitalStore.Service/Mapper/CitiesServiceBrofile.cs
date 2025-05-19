using AutoMapper;
using DigitalStore.BL.Cities.Entities;
using DigitalStore.Service.Controllers.Cities.Entities;

namespace DigitalStore.Service.Mapper;

public class CitiesServiceBrofile : Profile
{
    public CitiesServiceBrofile()
    {
        CreateMap<CreateCityRequest, CreateCityModel>();
        CreateMap<UpdateCityRequest, UpdateCityModel>();
        CreateMap<CitiesFilter, CitiesFilterModel>();
    }
}