using MediatR;
using ValetaxTest.Application.DTOs;

namespace ValetaxTest.Application.Queries.GetJournalById;

public record GetJournalByIdQuery(long Id) : IRequest<GetJournalByIdResponseDto>;