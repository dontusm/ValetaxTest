using Microsoft.EntityFrameworkCore;
using ValetaxTest.Domain.Interfaces;
using ValetaxTest.Domain.Models;
using ValetaxTest.Infrastructure.Data;

namespace ValetaxTest.Infrastructure.Repositories;

public class JournalRepository(DataContext context) : IJournalRepository
{
    public async Task<JournalEntry?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await context.JournalEntries.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<JournalEntry>> GetRangeAsync(int skip, int take, DateTime? from, DateTime? to, string? search,
        CancellationToken cancellationToken)
    {
        var query = ApplyFilter(context.JournalEntries, from, to, search);

        return await query
            .OrderByDescending(x => x.CreatedOn)
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(DateTime? from, DateTime? to, string? search, CancellationToken cancellationToken)
    {
        var query = ApplyFilter(context.JournalEntries, from, to, search);
        
        return await query.CountAsync(cancellationToken);
    }
    
    private IQueryable<JournalEntry> ApplyFilter(IQueryable<JournalEntry> query, DateTime? from, DateTime? to, string? search)
    {
        var readQuery = query.AsNoTracking();
        
        if (from.HasValue)
            readQuery = readQuery.Where(x => x.CreatedOn >= from.Value);

        if (to.HasValue)
            readQuery = readQuery.Where(x => x.CreatedOn <= to.Value);

        if (!string.IsNullOrWhiteSpace(search))
            readQuery = readQuery.Where(x => x.Message.Contains(search));

        return readQuery;
    }
}