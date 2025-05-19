namespace DigitalStore.Service.Controllers.Auth.Entities;

public record RegisterUserRequest(
    string PhoneNumber,
    string Password,
    string Surname,
    string Name,
    string? Patronymicname,
    string Email,
    DateOnly Birthday,
    string City,
    string? Store);