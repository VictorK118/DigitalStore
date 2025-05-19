using DigitalStore.BL.Users.Entity;

namespace DigitalStore.BL.Users.Manager;

public interface IUsersManager
{
    void DeleteUser(Guid id);
    UserModel UpdateUser(Guid id, UpdateUserModel updateModel);
}