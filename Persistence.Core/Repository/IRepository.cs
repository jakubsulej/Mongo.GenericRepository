using Persistence.Core.Models;

namespace Persistence.Core.Repository;

public interface IRepository<TEntity> where TEntity : class, IDocument
{
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);
}
