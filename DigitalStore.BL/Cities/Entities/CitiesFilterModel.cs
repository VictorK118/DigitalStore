namespace DigitalStore.BL.Cities.Entities;

public record CitiesFilterModel(
    DateTime? CreationTime, 
    DateTime? ModificationTime,
    string? NamePart);