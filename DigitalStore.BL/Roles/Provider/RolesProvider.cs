using AutoMapper;
using DigitalStore.BL.Exceptions.UsersExceptions;
using DigitalStore.BL.Roles.Entities;
using DigitalStore.DataAccess.Entities;
using DigitalStore.DataAccess.Repository;

namespace DigitalStore.BL.Roles.Provider;

public class RolesProvider(IRepository<RolesEntity> roleRepository, IMapper mapper): IRolesProvider
{
    public IEnumerable<RoleModel> GetRoles(RolesFilterModel filter = null)
    {
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;
        string? namePart = filter?.Name;

        var roles = roleRepository.GetAll(r =>
            (creationTime == null || r.CreationTime == creationTime) &&
            (modificationTime == null || r.ModificationTime == modificationTime) &&
            (namePart == null || r.Name.Contains(namePart)));
        return mapper.Map<IEnumerable<RoleModel>>(roles);
    }

    public RoleModel GetRoleInfo(int id)
    {
        var entity = roleRepository.GetById(id);
        if (entity == null)
            throw new RoleNotFoundException("Role not found");
        
        return mapper.Map<RoleModel>(entity);
    }
}