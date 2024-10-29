using System.ComponentModel.DataAnnotations.Schema;
 
namespace DigitalStore.DataAccess.Entities;

[Table("Users")]
public class UsersEntity: BaseEntity
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymicname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime Birthday { get; set; }

    public int RoleId { get; set; }
    public RolesEntity Role { get; set; }
    
    public int CityId { get; set; }
    public CitiesEntity City { get; set; }
    
    public int StoreId { get; set; }
    public OfflineStoresEntity Store { get; set; }
    
    public virtual ICollection<OrdersEntity> Orders { get; set; }
}