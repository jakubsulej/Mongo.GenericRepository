# Mongo.GenericRepository

A reusable and extensible MongoDB generic repository for .NET applications. This library provides a clean, abstracted Data Access Layer (DAL) for working with MongoDB using repository patterns similar to Entity Framework Core, enabling consistent and testable data operations.

## 📦 Features

- Generic CRUD operations (`Get`, `Insert`, `Update`, `Delete`)
- LINQ-style filtering with expressions
- Pagination support
- Bulk insert and delete
- Pluggable via dependency injection
- Attribute-based configuration for database and collection mapping

## 🚀 Getting Started

### Installation

Install via NuGet:

```bash
dotnet add package Mongo.GenericRepository
```

Or via NuGet Package Manager:
```powershell
Install-Package Mongo.GenericRepository
```
Requirements
.NET 8 or higher

MongoDB.Driver 3.4.0+

## 🛠️ Usage
### 1. Define your document model
Your models should implement the IDocument interface:

```csharp
public class User : IDocument
{
    public required string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
```

### 2. Register the repository
```csharp
services.AddSingleton<IMongoClient>(sp =>
    new MongoClient("mongodb://localhost:27017"));

services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
```

### 3. Inject and use the repository
```csharp
public class UserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }
}
```

## 📚 Repository Interface
```csharp
public interface IRepository<TEntity> where TEntity : class, IDocument
{
    Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<List<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take, CancellationToken cancellationToken);
    Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
    Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
    Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}
```
