using Microsoft.EntityFrameworkCore;
using ValetaxTest.Domain.Interfaces;
using ValetaxTest.Domain.Models;
using ValetaxTest.Infrastructure.Data;

namespace ValetaxTest.Infrastructure.Repositories;

public class TreeRepository(DataContext context) : ITreeRepository
{
    public async Task<Tree?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await context.Trees.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }
    
    public async Task<Tree> CreateAsync(string name, CancellationToken cancellationToken)
    {
        var tree = new Tree
        {
            Name = name
        };
        
        await context.Trees.AddAsync(tree, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return tree;
    }
}