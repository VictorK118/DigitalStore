using AutoMapper;
using DigitalStore.BL.Exceptions.UsersExceptions;
using DigitalStore.BL.Users.Entity;
using DigitalStore.DataAccess.Repository;
using DigitalStore.DataAccess.Entities;

namespace DigitalStore.BL.Users.Provider;

public class UsersProvider(IRepository<UsersEntity> userRepository, IMapper mapper) : IUsersProvider
{
    public IEnumerable<UserModel> GetUsers(UsersFilterModel? filter = null)
    {
        string? namePart = filter?.FullName;
        string? phoneNumberPart = filter?.PhoneNumber;
        string? emailPart = filter?.Email;
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;
        string? role = filter?.Role;
        string? city = filter?.City;
        string? store = filter?.Store;
        
        var users = userRepository.GetAll(u =>
            (namePart == null || (u.UserName).Contains(namePart)) &&
            (phoneNumberPart == null || u.PhoneNumber.Contains(phoneNumberPart)) &&
            (emailPart == null || u.Email.Contains(emailPart)) &&
            (creationTime == null || u.CreationTime == creationTime) &&
            (modificationTime == null || u.ModificationTime == modificationTime));
        return mapper.Map<IEnumerable<UserModel>>(users);
        throw new NotImplementedException();
    }

    public UserModel GerUserInfo(int id)
    {
        var entity = userRepository.GetById(id);
        if (entity == null)
            throw new UserNotFoundException("User not found");
        
        return mapper.Map<UserModel>(entity);
    }
}