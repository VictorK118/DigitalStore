using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DigitalStore.DataAccess.Entities;

[Table("Users")]
public class UsersEntity : IdentityUser<int>, IBaseEntity
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymicname { get; set; }
    public DateTime Birthday { get; set; }

    public int RoleId { get; set; }
    public RolesEntity Role { get; set; }
    
    public int CityId { get; set; }
    public CitiesEntity City { get; set; }
    
    public int StoreId { get; set; }
    public OfflineStoresEntity Store { get; set; }
    
    public virtual ICollection<OrdersEntity> Orders { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}