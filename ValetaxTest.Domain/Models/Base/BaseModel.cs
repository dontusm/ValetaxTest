namespace ValetaxTest.Domain.Models.Base;

/// <summary>
/// Base entity model containing common fields for all domain entities.
/// </summary>
public class BaseModel
{
    /// <summary>
    /// Unique identifier of the entity.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// UTC date and time when the entity was created.
    /// </summary>
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}