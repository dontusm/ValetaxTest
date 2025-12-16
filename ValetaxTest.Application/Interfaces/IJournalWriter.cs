namespace ValetaxTest.Application.Interfaces;

public interface IJournalWriter
{
    Task<long> WriteExceptionAsync(string message, string stackTrace,
        CancellationToken cancellationToken);
}