using MediatR;
using Microsoft.AspNetCore.Mvc;
using ValetaxTest.Api.Contracts;
using ValetaxTest.Application.Queries.GetJournalById;
using ValetaxTest.Application.Queries.GetJournalRange;

namespace ValetaxTest.Api.Controllers;

[ApiController]
[Route("api/user/journal")]
public class JournalController(IMediator mediator) : ControllerBase
{
    [HttpPost("getRange")]
    public async Task<IActionResult> GetRange([FromBody] GetJournalRangeRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetJournalRangeQuery(request.Skip, request.Take, request.From, request.To,
                request.SearchMessage), cancellationToken);

        return Ok(result);
    }

    [HttpPost("getSingle")]
    public async Task<IActionResult> GetSingle([FromQuery] long id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetJournalByIdQuery(id), cancellationToken);

        if (!result.IsSuccess)
            return NotFound(new { message = result.Error });
        
        return Ok(result.Data);
    }
}