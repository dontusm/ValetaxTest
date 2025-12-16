using ValetaxTest.Domain.Models.Base;

namespace ValetaxTest.Domain.Models;

/// <summary>
/// Represents a tree containing hierarchical nodes.
/// </summary>
public class Tree : BaseModel
{
    /// <summary>
    /// Tree name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Collection of nodes belonging to the tree.
    /// </summary>
    public List<Node> Nodes { get; set; } = [];
}