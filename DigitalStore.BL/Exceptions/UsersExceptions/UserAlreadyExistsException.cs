namespace DigitalStore.BL.Exceptions.UsersExceptions;

public class UserAlreadyExistsException(string message) : ApplicationException(message);