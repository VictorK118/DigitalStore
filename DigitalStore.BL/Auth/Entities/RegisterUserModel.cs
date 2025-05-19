namespace DigitalStore.BL.Auth.Entities;

public class RegisterUserModel
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymicname { get; set; }
    
    public string Email { get; set; }
    public DateOnly Birthday { get; set; }
    
    public string City { get; set; }
    
    public string? Store { get; set; }
}