using ValetaxTest.Domain.Models;

namespace ValetaxTest.Domain.Interfaces;

public interface INodeRepository
{
    Task<Node?> GetByIdAsync(long id, CancellationToken cancellationToken);
    
    Task<List<Node>> GetByTreeIdAsync(long treeId, CancellationToken cancellationToken);
    
    Task<Node> AddAsync(Node node, CancellationToken cancellationToken);
    
    Task UpdateAsync(Node node, CancellationToken cancellationToken);
        
    Task DeleteAsync(IEnumerable<Node> nodes, CancellationToken cancellationToken);

    Task<bool> ExistsWithNameAsync(long treeId, long? parentId, string name, long? excludeId,
        CancellationToken cancellationToken);

}