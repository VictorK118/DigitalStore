using DigitalStore.BL.Roles.Entities;

namespace DigitalStore.BL.Roles.Provider;

public interface IRolesProvider
{
    IEnumerable<RoleModel> GetRoles(RolesFilterModel filter = null);
    RoleModel GetRoleInfo(int id);
}