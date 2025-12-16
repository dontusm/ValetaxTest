using ValetaxTest.Domain.Enums;
using ValetaxTest.Domain.Models.Base;

namespace ValetaxTest.Domain.Models;

/// <summary>
/// Represents a journal event stored in the system.
/// </summary>
public class JournalEntry : BaseModel
{
    /// <summary>
    /// External event identifier.
    /// </summary>
    public long EventId { get; set; }

    /// <summary>
    /// Type of the journal event.
    /// </summary>
    public JournalEntryType Type { get; set; }
    
    /// <summary>
    /// Human-readable event message.
    /// </summary>
    public string Message { get; set; } = null!;
    
    /// <summary>
    /// Optional stack trace related to the event.
    /// </summary>
    public string? StackTrace { get; set; }
}