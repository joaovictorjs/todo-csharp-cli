using System.Linq.Expressions;
using ToDo.Domain.interfaces;

namespace ToDo.Infra.Interfaces;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    Task<int> CreateAsync(TEntity entity);
    Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> whereClause);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
}
