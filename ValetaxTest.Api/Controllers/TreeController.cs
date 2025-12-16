using MediatR;
using Microsoft.AspNetCore.Mvc;
using ValetaxTest.Application.Queries.GetTree;

namespace ValetaxTest.Api.Controllers;

/// <summary>
/// Provides access to tree structure API.
/// </summary>
[ApiController]
[Route("api/user/tree")]
public class TreeController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Returns the entire tree structure by tree name.
    /// </summary>
    /// <remarks>
    /// If the tree does not exist, it will be created automatically.
    /// </remarks>
    [HttpPost("get")]
    public async Task<IActionResult> GetTreeByName([FromQuery] string treeName, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetTreeQuery(treeName), cancellationToken);

        return Ok(result);
    }
}