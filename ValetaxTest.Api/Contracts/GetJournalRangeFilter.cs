namespace ValetaxTest.Api.Contracts;

public record GetJournalRangeRequest(
    int Skip,
    int Take,
    DateTime? From,
    DateTime? To,
    string? SearchMessage
);