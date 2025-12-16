using ValetaxTest.Domain.Models;

namespace ValetaxTest.Domain.Interfaces;

public interface ITreeRepository
{
    Task<Tree?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task<Tree> CreateAsync(string name, CancellationToken cancellationToken);
}