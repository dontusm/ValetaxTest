namespace ValetaxTest.Application.DTOs;

public class TreeDto
{
    public long Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public List<NodeDto> Roots { get; set; } = [];
}
