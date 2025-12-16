using MediatR;
using ValetaxTest.Application.Exceptions;
using ValetaxTest.Domain.Interfaces;

namespace ValetaxTest.Application.Commands.RenameNode;


public class RenameNodeCommandHandler(INodeRepository nodeRepository) : IRequestHandler<RenameNodeCommand, RenameNodeResponseDto>
{
    public async Task<RenameNodeResponseDto> Handle(RenameNodeCommand request, CancellationToken cancellationToken)
    {
        var node = await nodeRepository.GetByIdAsync(request.NodeId, cancellationToken);
        if (node == null) 
            return new RenameNodeResponseDto(false, null);
        
        var exists = await nodeRepository.ExistsWithNameAsync(node.TreeId, node.ParentId, request.NewNodeName,
            node.Id, cancellationToken);

        if (exists)
            throw new SecureException($"Node with name '{request.NewNodeName}' already exists under this parent");
        
        node.Name = request.NewNodeName;
        await nodeRepository.UpdateAsync(node, cancellationToken);
        
        return new RenameNodeResponseDto(true, node.Id);
    }
}