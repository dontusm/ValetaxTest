namespace ValetaxTest.Domain.Models.Base;

public class BaseModel
{
    public long Id { get; set; }
    
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}