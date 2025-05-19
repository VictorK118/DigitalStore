using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Orders")]
public class OrdersEntity: IBaseEntity
{
    public Guid OrderNum { get; set; }
    public DateTime RegistrationDate { get; set; }
    public float TotalCost { get; set; }

    public Guid UserId { get; set; }
    public UsersEntity User { get; set; }

    public virtual ICollection<SmartphonesInOrdersEntity> Smartphones { get; set; }
    
    public Guid Id { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}