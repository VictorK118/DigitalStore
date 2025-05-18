namespace DigitalStore.BL.Users.Entity;

public class UpdateUserModel
{
    public string? PhoneNumber { get; set; }
    public string? PasswordHash { get; set; }
    
    public string? Surname { get; set; }
    public string? Name { get; set; }
    public string? Patronymicname { get; set; }
    
    public string? Email { get; set; }
    public DateTime? Birthday { get; set; }
    
    public int? CityId { get; set; }
    
    public int? StoreId { get; set; }
}