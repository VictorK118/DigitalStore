namespace DigitalStore.BL.Exceptions.CitiesExceptions;

public class CityAlreadyExistsException(string message) : ApplicationException(message);