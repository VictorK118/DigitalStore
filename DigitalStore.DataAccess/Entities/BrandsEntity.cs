using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Brands")]
public class BrandsEntity: IBaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<SmartphonesEntity> Smartphones { get; set; }
    
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}