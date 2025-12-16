using MediatR;
using Microsoft.AspNetCore.Mvc;
using ValetaxTest.Application.Commands.CreateNode;
using ValetaxTest.Application.Commands.DeleteNode;
using ValetaxTest.Application.Commands.RenameNode;

namespace ValetaxTest.Api.Controllers;

[ApiController]
[Route("api/user/tree/node")]
public class NodeController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateNode([FromQuery] string treeName, [FromQuery] long? parentNodeId, [FromQuery] string nodeName,
        CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateNodeCommand(treeName, parentNodeId, nodeName), cancellationToken);

        return Ok(id);
    }

    [HttpPost("rename")]
    public async Task<IActionResult> RenameNode([FromQuery] long nodeId, [FromQuery] string newNodeName, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new RenameNodeCommand(nodeId, newNodeName), cancellationToken);

        return Ok(new
        {
            success = result.IsSuccess,
            id = result.NodeId
        });
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteNode([FromQuery] long nodeId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteNodeCommand(nodeId), cancellationToken);

        return Ok(new
        {
            success = result.IsSuccess,
            id = result.NodeId
        });
    }
}