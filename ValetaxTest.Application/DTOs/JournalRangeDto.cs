namespace ValetaxTest.Application.DTOs;

public class JournalRangeDto
{
    public int Skip { get; set; }
    
    public int Count { get; set; }
    
    public List<JournalInfoDto> Items { get; set; } = [];
}