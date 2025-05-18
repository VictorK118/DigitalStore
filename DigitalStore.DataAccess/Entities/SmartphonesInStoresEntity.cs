using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("SmartphonesInStores")]
public class SmartphonesInStoresEntity: IBaseEntity
{
    public int Amount { get; set; }
    
    public int SmartphoneId { get; set; }
    public SmartphonesEntity Smartphone { get; set; }
    
    public int StoreId { get; set; }
    public OfflineStoresEntity Store { get; set; }
    
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}