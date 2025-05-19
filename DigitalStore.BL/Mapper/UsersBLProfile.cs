using AutoMapper;
using DigitalStore.BL.Auth.Entities;
using DigitalStore.BL.Users.Entity;
using DigitalStore.DataAccess.Entities;

namespace DigitalStore.BL.Mapper;

public class UsersBLProfile : Profile
{
    public UsersBLProfile()
    {
        CreateMap<RegisterUserModel, UsersEntity>();
        CreateMap<UsersEntity, UserModel>();
    }
}