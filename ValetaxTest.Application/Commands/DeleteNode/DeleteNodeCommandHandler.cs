using MediatR;
using ValetaxTest.Application.Exceptions;
using ValetaxTest.Domain.Interfaces;
using ValetaxTest.Domain.Models;

namespace ValetaxTest.Application.Commands.DeleteNode;

public class DeleteNodeCommandHandler(INodeRepository nodeRepository) : IRequestHandler<DeleteNodeCommand, DeleteNodeResponseDto>
{
    public async Task<DeleteNodeResponseDto> Handle(DeleteNodeCommand request, CancellationToken cancellationToken)
    {
        var root = await nodeRepository.GetByIdAsync(request.NodeId, cancellationToken);
        if (root == null)
            return new DeleteNodeResponseDto(IsSuccess: true);
                
        var allNodes = await nodeRepository.GetByTreeIdAsync(root.TreeId, cancellationToken);

        var lookup = allNodes.ToLookup(x => x.ParentId);

        var toDelete = new List<Node>();
        var stack = new Stack<Node>();

        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            toDelete.Add(current);

            foreach (var child in lookup[current.Id])
            {
                stack.Push(child);
            }
        }
        
        await nodeRepository.DeleteAsync(toDelete, cancellationToken);
        
        return new DeleteNodeResponseDto(true, root.Id);
    }
}