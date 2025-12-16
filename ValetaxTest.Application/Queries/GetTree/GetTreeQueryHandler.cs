using MediatR;
using ValetaxTest.Application.DTOs;
using ValetaxTest.Domain.Interfaces;

namespace ValetaxTest.Application.Queries.GetTree;

public class GetTreeQueryHandler(ITreeRepository treeRepository, INodeRepository nodeRepository)
    : IRequestHandler<GetTreeQuery, TreeDto>
{
    public async Task<TreeDto> Handle(GetTreeQuery request, CancellationToken cancellationToken)
    {
        var tree = await treeRepository.GetByNameAsync(request.TreeName, cancellationToken)
                   ?? await treeRepository.CreateAsync(request.TreeName, cancellationToken);

        var nodes = await nodeRepository.GetByTreeIdAsync(tree.Id, cancellationToken);
        
        var dtoById = new Dictionary<long, NodeDto>(nodes.Count);
        
        foreach (var node in nodes)
        {
            dtoById[node.Id] = new NodeDto
            {
                Id = node.Id,
                Name = node.Name,
                Children = []
            };
        }
        
        foreach (var node in nodes)
        {
            if (node.ParentId is null)
                continue;
        
            if (dtoById.TryGetValue(node.ParentId.Value, out var parent))
            {
                parent.Children.Add(dtoById[node.Id]);
            }
        }
        
        var roots = nodes.Where(x => x.ParentId == null).Select(x => dtoById[x.Id]).ToList();
        
        return new TreeDto
        {
            Id = tree.Id,
            Name = tree.Name,
            Roots = roots
        };
    }
}