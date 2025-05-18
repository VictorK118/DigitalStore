using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Smartphones")]
public class SmartphonesEntity: IBaseEntity
{
    public string Name { get; set; }
    public float MainCameraResolution { get; set; }
    public float DisplaySize { get; set; }
    public int RAM { get; set; }
    public int StorageMemory { get; set; }
    public string Color { get; set; }
    public float Price { get; set; }

    public int BrandId { get; set; }
    public BrandsEntity Brand { get; set; }
    
    public int ChipId { get; set; }
    public ChipsEntity Chip { get; set; }
    
    public virtual ICollection<SmartphonesInOrdersEntity> Orders { get; set; }
    
    public virtual ICollection<SmartphonesInStoresEntity> Stores { get; set; }
    
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}