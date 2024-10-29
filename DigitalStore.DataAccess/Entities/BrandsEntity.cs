using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Brands")]
public class BrandsEntity: BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<SmartphonesEntity> Smartphones { get; set; }
}