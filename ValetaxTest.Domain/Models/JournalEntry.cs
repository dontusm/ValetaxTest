using ValetaxTest.Domain.Enums;
using ValetaxTest.Domain.Models.Base;

namespace ValetaxTest.Domain.Models;

public class JournalEntry : BaseModel
{
    public long EventId { get; set; }

    public JournalEntryType Type { get; set; }
    
    public string Message { get; set; } = null!;
    
    public string? StackTrace { get; set; }
}