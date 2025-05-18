namespace DigitalStore.BL.Users.Entity;

public class UsersFilterModel
{
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    
    public DateTime? CreationTime { get; set; }
    public DateTime? ModificationTime { get; set; }
    
    public string? Role { get; set; }
    
    public string? City { get; set; }
    
    public string? Store { get; set; }
}