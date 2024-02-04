using Core.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core;
public abstract class Repository<TEntity> : IAsyncRepository<TEntity>, IRepository<TEntity>
    where TEntity : Entity
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public virtual IQueryable<TEntity> Query()
    {
        return _context.Set<TEntity>();
    }

    public TEntity Add(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Added;
        _context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }

    public void Delete(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Deleted;
        _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public TEntity? Get(Expression<Func<TEntity, bool>>? predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var query = Query().Where(predicate);
        if (include != null) query = include(query);
        return query.FirstOrDefault();
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool isTracking = false, int limit = 100, int page = 0)
    {
        var query = Query();
        if (predicate != null) query = query.Where(predicate);
        if (include != null) query = include(query);
        if (orderBy != null) query = orderBy(query);
        return query.ToList();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool isTracking = false, int limit = 100, int page = 0)
    {
        var query = Query();
        if (isTracking == false) query.AsNoTracking();
        if (predicate != null) query = query.Where(predicate);
        if (include != null) query = include(query);
        if (orderBy != null) query = orderBy(query);
        query.Skip(limit).Take(page*limit);
        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var query = Query().Where(predicate);
        if (include != null) query = include(query);
        return await query.FirstOrDefaultAsync();
    }

    public TEntity Update(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Modified;
        _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry<TEntity>(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }
}