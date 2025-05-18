using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Cities")]
public class CitiesEntity: IBaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<UsersEntity> Users { get; set; }
    public virtual ICollection<OfflineStoresEntity> Stores { get; set; }
    
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}