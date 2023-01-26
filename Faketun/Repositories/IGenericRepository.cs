using Faketun.Models;

namespace Faketun.Repositories;

public interface IGenericRepository<TEntity> where TEntity : IEntity
{
    IQueryable<TEntity> GetAll(bool deleted = true);
    Task<TEntity> GetByIdAsync(int id);
    Task<bool> Create(TEntity entity);
    Task<bool> Update(int id, TEntity entity);
    Task<bool> Delete(int id);
    Task<bool> LogicalDelete(int id);
}
