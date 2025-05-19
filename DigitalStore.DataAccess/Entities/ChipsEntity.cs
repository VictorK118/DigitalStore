using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Chips")]
public class ChipsEntity: IBaseEntity
{
    public string Name { get; set; }
    public string CPU { get; set; }
    public string GPU { get; set; }
    
    public virtual ICollection<SmartphonesEntity> Smartphones { get; set; }
    
    public Guid Id { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}