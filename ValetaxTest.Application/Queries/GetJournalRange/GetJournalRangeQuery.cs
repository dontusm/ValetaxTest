using MediatR;
using ValetaxTest.Application.DTOs;

namespace ValetaxTest.Application.Queries.GetJournalRange;

public record GetJournalRangeQuery(
    int Skip,
    int Take,
    DateTime? From,
    DateTime? To,
    string? SearchMessage) : IRequest<JournalRangeDto>;
