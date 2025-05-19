using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("SmartphonesInStores")]
public class SmartphonesInStoresEntity: IBaseEntity
{
    public int Amount { get; set; }
    
    public Guid SmartphoneId { get; set; }
    public SmartphonesEntity Smartphone { get; set; }
    
    public Guid StoreId { get; set; }
    public OfflineStoresEntity Store { get; set; }
    
    public Guid Id { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}