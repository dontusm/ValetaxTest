using MediatR;
using ValetaxTest.Application.Exceptions;
using ValetaxTest.Domain.Interfaces;
using ValetaxTest.Domain.Models;

namespace ValetaxTest.Application.Commands.CreateNode;

public class CreateNodeCommandHandler(ITreeRepository treeRepository, INodeRepository nodeRepository) : IRequestHandler<CreateNodeCommand, long>
{
    public async Task<long> Handle(CreateNodeCommand request, CancellationToken cancellationToken)
    {
        var tree = await treeRepository.GetByNameAsync(request.TreeName, cancellationToken);

        var isNewTree = tree == null;

        if (isNewTree)
        {
            if (request.ParentId != null)
                throw new SecureException(
                    $"Cannot specify parent node '{request.ParentId}' when creating a new tree '{request.TreeName}'");

            tree = await treeRepository.CreateAsync(request.TreeName, cancellationToken);
        }
        else
        {
            var exists = await nodeRepository.ExistsWithNameAsync(tree.Id, request.ParentId, request.NodeName, excludeId: null,
                cancellationToken);

            if (exists)
                throw new SecureException($"Node with {request.NodeName} name already exists");
        }

        var node = new Node
        {
            Name = request.NodeName,
            ParentId = request.ParentId,
            TreeId = tree.Id
        };

        var created = await nodeRepository.AddAsync(node, cancellationToken);
        return created.Id; 
    }
}