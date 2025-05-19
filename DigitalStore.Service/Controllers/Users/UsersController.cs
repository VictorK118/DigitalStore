using AutoMapper;
using DigitalStore.BL.Users.Manager;
using DigitalStore.BL.Users.Provider;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger; 

namespace DigitalStore.Service.Controllers.Users;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUsersManager _usersManager;
    private IUsersProvider _usersProvider;
    private IMapper _mapper;
    private ILogger _logger;

    public UsersController(IUsersManager usersManager, IUsersProvider usersProvider,
    IMapper mapper, ILogger logger)
    {
        _usersManager = usersManager;
        _usersProvider = usersProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetUsers()
    {
        try
        {
            var users = _usersProvider.GetUsers();
            return Ok(users);
        }
        catch (Exception e)
        {
            _logger.Error(e.ToString());
            return BadRequest("Что-то пошло не так");
        }
    }
}