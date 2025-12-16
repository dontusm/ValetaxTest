namespace ValetaxTest.Application.DTOs;

public class NodeReadDto
{
    public long Id { get; init; }
    public string Name { get; init; } = null!;
    public long? ParentId { get; init; }
}