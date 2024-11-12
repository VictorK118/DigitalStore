using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("OfflineStores")]
public class OfflineStoresEntity: BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    
    public int CityId { get; set; }
    public CitiesEntity City { get; set; }
    
    public virtual ICollection<UsersEntity> Users { get; set; }
    
    public virtual ICollection<SmartphonesInStoresEntity> Smartphones { get; set; }
}