using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Orders")]
public class OrdersEntity: BaseEntity
{
    public int OrderNum { get; set; }
    public DateTime RegistrationDate { get; set; }
    public float TotalCost { get; set; }

    public int UserId { get; set; }
    public UsersEntity User { get; set; }
    
    public virtual ICollection<SmartphonesEntity> Smartphones { get; set; }
}