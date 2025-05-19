using DigitalStore.BL.Auth.Entities;

namespace DigitalStore.BL.Auth;

public interface IAuthService
{
    Task<TokenResponce> RegisterUserAsync(RegisterUserModel model);
    Task<TokenResponce> LoginUserAsync(LoginUserModel model);
}