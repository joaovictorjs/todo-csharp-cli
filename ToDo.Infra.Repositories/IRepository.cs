using System;
using ToDo.Domain.interfaces;

namespace ToDo.Infra.Repositories.Interfaces;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    Task MigrateAsync();
}
