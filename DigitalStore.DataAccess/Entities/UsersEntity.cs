using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DigitalStore.DataAccess.Entities;

[Table("Users")]
public class UsersEntity : IdentityUser<Guid>, IBaseEntity
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymicname { get; set; }
    public DateOnly Birthday { get; set; }

    public ICollection<UserRole>? Roles { get; set; }
    
    public Guid? CityId { get; set; }
    public CitiesEntity City { get; set; }
    
    public Guid? StoreId { get; set; }
    public OfflineStoresEntity Store { get; set; }
    
    public virtual ICollection<OrdersEntity> Orders { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}