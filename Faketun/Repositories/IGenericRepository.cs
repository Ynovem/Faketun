using Faketun.Models;

namespace Faketun.Repositories;

public interface IGenericRepository<TEntity> where TEntity : IEntity
{
    IQueryable<TEntity> GetAll();
    Task<TEntity> GetByIdAsync(int id);
    Task Create(TEntity entity);
    Task Update(int id, TEntity entity);
    Task Delete(int id);
}
