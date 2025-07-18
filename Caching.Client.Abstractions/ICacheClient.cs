using Core.Abstractions.Models;

namespace Caching.Client.Abstractions;

public interface ICacheClient
{
    Task<TEntity?> GetAsync<TEntity>(string key, CancellationToken cancellationToken = default) where TEntity : class, IDocument;
    Task SetAsync<TEntity>(string key, TEntity value, TimeSpan? absoluteExpiration = null, CancellationToken cancellationToken = default) where TEntity : class, IDocument;
    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
}
