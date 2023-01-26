using Faketun.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Faketun.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly Context _db;

    public GenericRepository(Context db)
    {
        _db = db;
    }

    public IQueryable<TEntity> GetAll(bool deleted)
    {
        return _db.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().IgnoreQueryFilters().Where(i => i.Deleted == deleted);
    }

    public TEntity GetById(int id)
    {
        return _db.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id == id);
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> Create(TEntity entity)
    {
        await _db.Set<TEntity>().AddAsync(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(int id, TEntity entity)
    {
        _db.Set<TEntity>().Update(entity);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await GetByIdAsync(id);
        _db.Set<TEntity>().Remove(entity);
        return await _db.SaveChangesAsync() > 0;
    }
    public async Task<bool> LogicalDelete(int id)
    {
        var entity = _db.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().IgnoreQueryFilters().FirstOrDefault(e => e.Id == id);
        if (entity == null)
        {
            return false;
        }

        entity.Deleted = true;
        _db.Set<TEntity>().Update(entity);
        var r = await _db.SaveChangesAsync();
        return r > 0;
    }
}
