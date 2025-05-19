namespace DigitalStore.Service.Controllers.Cities.Entities;

public record CitiesFilter(
    DateTime? CreationTime, 
    DateTime? ModificationTime,
    string? NamePart);