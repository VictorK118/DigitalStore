using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Cities")]
public class CitiesEntity: BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<UsersEntity> Users { get; set; }
    public virtual ICollection<OfflineStoresEntity> Stores { get; set; }
}