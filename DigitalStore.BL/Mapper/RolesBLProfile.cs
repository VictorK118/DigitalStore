using AutoMapper;
using DigitalStore.BL.Roles.Entities;
using DigitalStore.DataAccess.Entities;

namespace DigitalStore.BL.Mapper;

public class RolesBLProfile: Profile
{
    public RolesBLProfile()
    {
        CreateMap<RolesEntity, RoleModel>()
            .ForMember(x => x.Id, y => y.MapFrom(src => src.Id));
    }
}