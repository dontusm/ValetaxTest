using MediatR;
using Microsoft.AspNetCore.Mvc;
using ValetaxTest.Application.Commands.CreateNode;
using ValetaxTest.Application.Commands.DeleteNode;
using ValetaxTest.Application.Commands.RenameNode;

namespace ValetaxTest.Api.Controllers;

/// <summary>
/// Provides API for managing tree nodes.
/// </summary>
[ApiController]
[Route("api/user/tree/node")]
public class NodeController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Creates a new node in a tree.
    /// </summary>
    /// <remarks>
    /// If the tree does not exist, it will be created automatically.
    /// Parent node cannot be specified for a newly created tree.
    /// </remarks>
    [HttpPost("create")]
    public async Task<IActionResult> CreateNode([FromQuery] string treeName, [FromQuery] long? parentNodeId, [FromQuery] string nodeName,
        CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateNodeCommand(treeName, parentNodeId, nodeName), cancellationToken);

        return Ok(id);
    }

    /// <summary>
    /// Renames an existing node.
    /// </summary>
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

    /// <summary>
    /// Deletes a node and all its child nodes.
    /// </summary>
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