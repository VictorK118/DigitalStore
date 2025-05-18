namespace DigitalStore.BL.Exceptions.UsersExceptions;

public class UserNotFoundException(string message) : ApplicationException(message);