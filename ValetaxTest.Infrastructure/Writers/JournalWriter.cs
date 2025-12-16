using ValetaxTest.Application.Interfaces;
using ValetaxTest.Domain.Enums;
using ValetaxTest.Domain.Models;
using ValetaxTest.Infrastructure.Data;

namespace ValetaxTest.Infrastructure.Writers;

public class JournalWriter(DataContext context) : IJournalWriter
{
    public async Task<long> WriteExceptionAsync(
        string message,
        string stackTrace,
        CancellationToken cancellationToken)
    {
        var entry = new JournalEntry
        {
            Type = JournalEntryType.Exception,
            Message = message,
            StackTrace = stackTrace
        };

        context.JournalEntries.Add(entry);
        await context.SaveChangesAsync(cancellationToken);

        entry.EventId = entry.Id;
        await context.SaveChangesAsync(cancellationToken);

        return entry.EventId;
    }
}