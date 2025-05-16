using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace BankCreditApp.Core.Repositories;

public interface IAsyncRepository<T, TId> where T : Entity<TId>
{
    // Get Single Entity
    Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate, 
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false,
        CancellationToken cancellationToken = default);

    // Get List with Pagination
    Task<PaginatedList<T>> GetListAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        PaginationParams? pagination = null,
        bool enableTracking = true,
        bool withDeleted = false,
        CancellationToken cancellationToken = default);

    // Check if entity exists
    Task<bool> AnyAsync(
        Expression<Func<T, bool>> predicate,
        bool withDeleted = false,
        CancellationToken cancellationToken = default);

    // Add single entity
    Task<T> AddAsync(
        T entity,
        CancellationToken cancellationToken = default);

    // Add multiple entities
    Task<ICollection<T>> AddRangeAsync(
        ICollection<T> entities,
        CancellationToken cancellationToken = default);

    // Update single entity
    Task<T> UpdateAsync(
        T entity,
        CancellationToken cancellationToken = default);

    // Update multiple entities
    Task<ICollection<T>> UpdateRangeAsync(
        ICollection<T> entities,
        CancellationToken cancellationToken = default);

    // Delete single entity (Soft Delete)
    Task<T> DeleteAsync(
        T entity,
        bool permanent = false,
        CancellationToken cancellationToken = default);

    // Delete multiple entities (Soft Delete)
    Task<ICollection<T>> DeleteRangeAsync(
        ICollection<T> entities,
        bool permanent = false,
        CancellationToken cancellationToken = default);
} 