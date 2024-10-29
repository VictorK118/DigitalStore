using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Chips")]
public class ChipsEntity: BaseEntity
{
    public string Name { get; set; }
    public string CPU { get; set; }
    public string GPU { get; set; }
    
    public virtual ICollection<SmartphonesEntity> Smartphones { get; set; }
}