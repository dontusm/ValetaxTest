using MediatR;
using ValetaxTest.Application.DTOs;
using ValetaxTest.Application.Exceptions;
using ValetaxTest.Domain.Interfaces;

namespace ValetaxTest.Application.Queries.GetJournalById;

public class GetJournalByIdQueryHandler(IJournalRepository journalRepository) 
    : IRequestHandler<GetJournalByIdQuery, GetJournalByIdResponseDto>
{
    public async Task<GetJournalByIdResponseDto> Handle(GetJournalByIdQuery request, CancellationToken cancellationToken)
    {
        var entry = await journalRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entry == null)
            return new GetJournalByIdResponseDto(false, null, "Journal entry not found");

        return new GetJournalByIdResponseDto(
            IsSuccess: true,
            Data: new JournalDto
            {
                Id = entry.Id,
                EventId = entry.EventId,
                CreatedAt = entry.CreatedOn,
                Text = entry.Message
            },
            Error: null);
    }
}