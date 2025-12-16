using ValetaxTest.Domain.Models.Base;

namespace ValetaxTest.Domain.Models;

public class Tree : BaseModel
{
    public required string Name { get; set; }

    public List<Node> Nodes { get; set; } = [];
}