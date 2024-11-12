using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("SmartphonesInStores")]
public class SmartphonesInStoresEntity: BaseEntity
{
    public int Amount { get; set; }
    
    public int SmartphoneId { get; set; }
    public SmartphonesEntity Smartphone { get; set; }
    
    public int StoreId { get; set; }
    public OfflineStoresEntity Store { get; set; }
}