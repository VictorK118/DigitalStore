using AutoMapper;
using DigitalStore.BL.Cities.Entities;
using DigitalStore.DataAccess.Entities;

namespace DigitalStore.BL.Mapper;

public class CitiesBLProfile: Profile
{
    public CitiesBLProfile()
    {
        CreateMap<CitiesEntity, CityModel>();

        CreateMap<CreateCityModel, CitiesEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore());
    }
}