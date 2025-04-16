using System.Linq.Expressions;

namespace ToDo.Domain.Interfaces;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    Task<int> CreateAsync(TEntity entity);
    Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> whereClause);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
}