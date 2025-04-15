using ToDo.Domain.interfaces;

namespace ToDo.Infra.Interfaces;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    Task MigrateAsync();
}
