using DigitalStore.BL.Users.Entity;

namespace DigitalStore.BL.Users.Manager;

public interface IUsersManager
{
    UserModel CreateUser(CreateUserModel createModel);
    void DeleteUser(int id);
    UserModel UpdateUser(int id, UpdateUserModel updateModel);
}