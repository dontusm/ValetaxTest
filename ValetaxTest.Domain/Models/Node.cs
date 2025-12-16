using ValetaxTest.Domain.Models.Base;

namespace ValetaxTest.Domain.Models;

public class Node : BaseModel 
{
    public required string Name { get; set; } = null!;
    
    public long TreeId { get; set; }

    public Tree Tree { get; set; } = null!;
    
    public long? ParentId { get; set; }

    public Node? Parent { get; set; }

    public List<Node> Children { get; set; } = [];
}