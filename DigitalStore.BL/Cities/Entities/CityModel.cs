namespace DigitalStore.BL.Cities.Entities;

public class CityModel
{
    public int Id { get; set; }
    
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    
    public string Name { get; set; }
}