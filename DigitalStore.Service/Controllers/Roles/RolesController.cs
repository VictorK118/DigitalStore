using AutoMapper;
using DigitalStore.BL.Roles.Entities;
using DigitalStore.BL.Roles.Provider;
using DigitalStore.Service.Controllers.Roles.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DigitalStore.Service.Controllers.Roles;

[ApiController]
[Route("[controller]")]
public class RolesController(
    IRolesProvider rolesProvider,
    IMapper mapper,
    ILogger logger)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllRoles()
    {
        try
        {
            var roles = rolesProvider.GetRoles();
            return Ok(new RolesListResponse()
            {
                Roles = roles.ToList()
            });
        }
        catch (Exception e)
        {
            // logger.Error(e.ToString());
            return BadRequest("Что-то пошло не так, повторите попытку позже");
        }
    }
    
    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredRoles([FromQuery] RolesFilter filter)
    {
        try
        {
            var filterModel = mapper.Map<RolesFilterModel>(filter);
            var roles = rolesProvider.GetRoles(filterModel);
            return Ok(new RolesListResponse()
            {
                Roles = roles.ToList()
            });
        }
        catch (Exception e)
        {
            // logger.Error(e.ToString());
            return BadRequest("Что-то пошло не так, повторите попытку позже");
        }
    }
}