namespace DigitalStore.BL.Roles.Entities;

public class RoleModel
{
    public int Id { get; set; }
    
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
}