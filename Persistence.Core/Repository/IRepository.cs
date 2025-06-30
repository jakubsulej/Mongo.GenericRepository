using Persistence.Core.Models;
using System.Linq.Expressions;

namespace Persistence.Core.Repository;

/// <summary>
/// Generic repository interface for MongoDB documents.
/// </summary>
public interface IRepository<TEntity> where TEntity : class, IDocument
{
    /// <summary>
    /// Counts the number of documents that match the given predicate.
    /// </summary>
    /// <param name="predicate">Optional filter expression; if null, counts all documents.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The number of matching documents.</returns>
    Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a document by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the document to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes all documents that match the specified filter expression.
    /// </summary>
    /// <param name="predicate">Filter expression for selecting documents to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Finds and returns all documents that match the specified filter expression.
    /// </summary>
    /// <param name="predicate">Filter expression for querying documents.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of matching documents.</returns>
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Finds the first document that matches the given predicate, or null if none found.
    /// </summary>
    /// <param name="predicate">Filter expression for querying documents.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The first matching document or null.</returns>
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves all documents in the collection.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of all documents.</returns>
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a document by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the document to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The matching document or null if not found.</returns>
    Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a paginated list of documents matching the specified predicate.
    /// </summary>
    /// <param name="predicate">Filter expression for querying documents.</param>
    /// <param name="skip">The number of documents to skip.</param>
    /// <param name="take">The number of documents to take.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of documents in the specified page.</returns>
    Task<List<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take, CancellationToken cancellationToken);

    /// <summary>
    /// Inserts a new document into the collection.
    /// </summary>
    /// <param name="entity">The document to insert.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Inserts multiple new documents into the collection.
    /// </summary>
    /// <param name="entities">The documents to insert.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing document in the collection.
    /// </summary>
    /// <param name="entity">The document with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
