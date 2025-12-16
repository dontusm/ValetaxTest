using ValetaxTest.Domain.Models;

namespace ValetaxTest.Domain.Interfaces;

public interface IJournalRepository
{
    Task<JournalEntry?> GetByIdAsync(long id, CancellationToken cancellationToken);

    Task<List<JournalEntry>> GetRangeAsync(int skip, int take, DateTime? from, DateTime? to, string? search,
        CancellationToken cancellationToken);

    Task<int> CountAsync(DateTime? from, DateTime? to, string? search, CancellationToken cancellationToken);
}