using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("SmartphonesInOrders")]
public class SmartphonesInOrdersEntity: IBaseEntity
{
    public int Amount { get; set; }
    
    public Guid SmartphoneId { get; set; }
    public SmartphonesEntity Smartphone { get; set; }
    
    public Guid OrderId { get; set; }
    public OrdersEntity Order { get; set; }
    
    public Guid Id { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}