using Faketun.Models;
using Microsoft.EntityFrameworkCore;

namespace Faketun.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly Context _db;

    public GenericRepository(Context db)
    {
        _db = db;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _db.Set<TEntity>().AsNoTracking();
    }

    public TEntity GetById(int id)
    {
        return _db.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id == id);
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Create(TEntity entity)
    {
        await _db.Set<TEntity>().AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Update(int id, TEntity entity)
    {
        _db.Set<TEntity>().Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await GetByIdAsync(id);
        _db.Set<TEntity>().Remove(entity);
        await _db.SaveChangesAsync();
    }
}
