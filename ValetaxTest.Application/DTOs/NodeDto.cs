namespace ValetaxTest.Application.DTOs;

public class NodeDto
{
    public long Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public List<NodeDto> Children { get; set; } = [];
}