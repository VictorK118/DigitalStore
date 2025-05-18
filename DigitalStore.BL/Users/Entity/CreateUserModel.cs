namespace DigitalStore.BL.Users.Entity;

public class CreateUserModel
{
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymicname { get; set; }
    
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    
    public string Role { get; set; }
    
    public string City { get; set; }
    
    public string? Store { get; set; }
}