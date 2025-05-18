using DigitalStore.BL.Users.Entity;

namespace DigitalStore.BL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers(UsersFilterModel filter = null);
    UserModel GerUserInfo(int id);
}