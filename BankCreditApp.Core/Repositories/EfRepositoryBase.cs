using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BankCreditApp.Core.Repositories;

public class EfRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool enableTracking = true,
        bool withDeleted = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();
        
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        
        if (include != null)
            queryable = include(queryable);
            
        if (!withDeleted)
            queryable = queryable.Where(e => e.DeletedDate == null);
            
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<PaginatedList<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        PaginationParams? pagination = null,
        bool enableTracking = true,
        bool withDeleted = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();

        if (include != null)
            queryable = include(queryable);

        if (!withDeleted)
            queryable = queryable.Where(e => e.DeletedDate == null);

        if (predicate != null)
            queryable = queryable.Where(predicate);

        if (orderBy != null)
            queryable = orderBy(queryable);

        if (pagination == null)
            pagination = new PaginationParams { PageNumber = 1, PageSize = 10 };
        
        pagination.PageNumber = Math.Max(1, pagination.PageNumber);
        pagination.PageSize = Math.Max(1, pagination.PageSize);

        var totalCount = await queryable.CountAsync(cancellationToken);
        var items = await queryable
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<TEntity>(items, totalCount, pagination.PageNumber, pagination.PageSize);
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool withDeleted = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();

        if (!withDeleted)
            queryable = queryable.Where(e => e.DeletedDate == null);

        return await queryable.AnyAsync(predicate, cancellationToken);
    }

    public async Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
            entity.CreatedDate = DateTime.UtcNow;
            
        await Context.AddRangeAsync(entities, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> UpdateRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
            entity.UpdatedDate = DateTime.UtcNow;
            
        Context.UpdateRange(entities);
        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity> DeleteAsync(
        TEntity entity,
        bool permanent = false,
        CancellationToken cancellationToken = default)
    {
        if (!permanent)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Update(entity);
        }
        else
        {
            Context.Remove(entity);
        }

        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ICollection<TEntity>> DeleteRangeAsync(
        ICollection<TEntity> entities,
        bool permanent = false,
        CancellationToken cancellationToken = default)
    {
        if (!permanent)
        {
            foreach (var entity in entities)
                entity.DeletedDate = DateTime.UtcNow;
            Context.UpdateRange(entities);
        }
        else
        {
            Context.RemoveRange(entities);
        }

        await Context.SaveChangesAsync(cancellationToken);
        return entities;
    }
} 