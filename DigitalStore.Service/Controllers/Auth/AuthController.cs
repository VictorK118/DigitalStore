using AutoMapper;
using DigitalStore.BL.Auth;
using DigitalStore.BL.Auth.Entities;
using DigitalStore.Service.Controllers.Auth.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigitalStore.Service.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public AuthController(IMapper mapper, IAuthService authService)
    {
        _mapper = mapper;
        _authService = authService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<TokenResponce>> RegisterUser([FromForm] RegisterUserRequest request)
    {
        var registerModel = _mapper.Map<RegisterUserModel>(request);
        var tokens = await _authService.RegisterUserAsync(registerModel);
        return Ok(tokens);
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenResponce>> LoginUser([FromForm] LoginUserRequest request)
    {
        var authorizeModel = _mapper.Map<LoginUserModel>(request);
        var tokens = await _authService.LoginUserAsync(authorizeModel);
        return Ok(tokens);
    }
}