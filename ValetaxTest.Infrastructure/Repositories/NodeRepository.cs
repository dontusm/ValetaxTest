using Microsoft.EntityFrameworkCore;
using ValetaxTest.Application.DTOs;
using ValetaxTest.Domain.Interfaces;
using ValetaxTest.Domain.Models;
using ValetaxTest.Infrastructure.Data;

namespace ValetaxTest.Infrastructure.Repositories;

public class NodeRepository(DataContext context) : INodeRepository
{
    public async Task<Node?> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await context.Nodes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Node>> GetByTreeIdAsync(long treeId, CancellationToken cancellationToken) // добавить AsNoTracking - если никак не меняется сущность ,которую достаю; сделать select на три поля Id, Name, Parent - тянуть отдельной Dto 
    {
        return await context.Nodes
            .AsNoTracking()
            .Where(x => x.TreeId == treeId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Node> AddAsync(Node node, CancellationToken cancellationToken)
    {
        await context.Nodes.AddAsync(node, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return node;
    }
    
    public async Task UpdateAsync(Node node, CancellationToken cancellationToken)
    {
        context.Nodes.Update(node);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<bool> ExistsWithNameAsync(long treeId, long? parentId, string name, long? excludeId,
        CancellationToken cancellationToken)
    {
        return await context.Nodes.AnyAsync(x =>
            x.TreeId == treeId && x.ParentId == parentId && x.Name == name &&
               (excludeId == null || x.Id != excludeId), cancellationToken);
    }
    public async Task DeleteAsync(IEnumerable<Node> nodes, CancellationToken cancellationToken)
    {
        context.Nodes.RemoveRange(nodes);
        await context.SaveChangesAsync(cancellationToken);
    }
}