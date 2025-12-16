using ValetaxTest.Application.DTOs;

namespace ValetaxTest.Application.Queries.GetJournalById;

public record GetJournalByIdResponseDto(bool IsSuccess, JournalDto? Data, string? Error);