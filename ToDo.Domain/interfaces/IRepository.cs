using System.Linq.Expressions;

namespace ToDo.Domain.Interfaces;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    Task<int> CreateAsync(TEntity entity);
    Task<List<TEntity>> ReadAsync(params Expression<Func<TEntity, bool>>[] whereClauses);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
}
