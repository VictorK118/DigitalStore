using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Orders")]
public class OrdersEntity: IBaseEntity
{
    public int OrderNum { get; set; }
    public DateTime RegistrationDate { get; set; }
    public float TotalCost { get; set; }

    public int UserId { get; set; }
    public UsersEntity User { get; set; }

    public virtual ICollection<SmartphonesInOrdersEntity> Smartphones { get; set; }
    
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}