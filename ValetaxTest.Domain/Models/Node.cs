using ValetaxTest.Domain.Models.Base;

namespace ValetaxTest.Domain.Models;

/// <summary>
/// Represents a node in a hierarchical tree structure.
/// </summary>
public class Node : BaseModel 
{
    /// <summary>
    /// Node name.
    /// </summary>
    public required string Name { get; set; } = null!;
    
    /// <summary>
    /// Identifier of the tree this node belongs to.
    /// </summary>
    public long TreeId { get; set; }

    /// <summary>
    /// Tree navigation property.
    /// </summary>
    public Tree Tree { get; set; } = null!;
    
    /// <summary>
    /// Parent node identifier. Null for root nodes.
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// Parent node navigation property.
    /// </summary>
    public Node? Parent { get; set; }

    /// <summary>
    /// Child nodes.
    /// </summary>
    public List<Node> Children { get; set; } = [];
}