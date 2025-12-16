using MediatR;
using ValetaxTest.Application.DTOs;
using ValetaxTest.Domain.Interfaces;

namespace ValetaxTest.Application.Queries.GetJournalRange;

public class GetJournalRangeQueryHandler(IJournalRepository journalRepository) 
    : IRequestHandler<GetJournalRangeQuery, JournalRangeDto>
{
    public async Task<JournalRangeDto> Handle(GetJournalRangeQuery request, CancellationToken cancellationToken)
    {
        var items = await journalRepository.GetRangeAsync(request.Skip, request.Take, request.From, request.To,
                                            request.SearchMessage, cancellationToken);

        var count = await journalRepository.CountAsync(request.From, request.To, request.SearchMessage, cancellationToken);

        return new JournalRangeDto
        {
            Skip = request.Skip,
            Count = count,
            Items = items.Select(x => new JournalInfoDto
            {
                Id = x.Id,
                EventId = x.EventId,
                CreatedAt = x.CreatedOn
            }).ToList()
        };
    }
}