using MediatR;
using Microsoft.AspNetCore.Mvc;
using ValetaxTest.Application.Queries.GetTree;

namespace ValetaxTest.Api.Controllers;

[ApiController]
[Route("api/user/tree")]
public class TreeController(IMediator mediator) : ControllerBase
{
    [HttpPost("get")]
    public async Task<IActionResult> GetTreeByName([FromQuery] string treeName, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetTreeQuery(treeName), cancellationToken);

        return Ok(result);
    }
}