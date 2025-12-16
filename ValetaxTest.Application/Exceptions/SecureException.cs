namespace ValetaxTest.Application.Exceptions;

public class SecureException : Exception
{
    public SecureException(string message)
        : base(message)
    {
    }
}