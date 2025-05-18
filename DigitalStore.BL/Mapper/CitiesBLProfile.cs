using AutoMapper;
using DigitalStore.BL.Cities.Entities;
using DigitalStore.DataAccess.Entities;

namespace DigitalStore.BL.Mapper;

public class CitiesBLProfile: Profile
{
    public CitiesBLProfile()
    {
        CreateMap<CitiesEntity, CityModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.Id));
    }
}