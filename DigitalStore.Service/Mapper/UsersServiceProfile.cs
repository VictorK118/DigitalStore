using AutoMapper;
using DigitalStore.BL.Auth.Entities;
using DigitalStore.Service.Controllers.Auth.Entities;

namespace DigitalStore.Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<LoginUserRequest, LoginUserModel>();
        CreateMap<RegisterUserRequest, RegisterUserModel>();
    }
}