using System;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.interfaces;
using ToDo.Infra.Contexts;
using ToDo.Infra.Interfaces;

namespace ToDo.Infra.Repositories;

public class Repository<TEntity>(IDbContextFactory<SqliteContext> contextFactory)
    : IRepository<TEntity>
    where TEntity : IEntity
{
    public async Task MigrateAsync()
    {
        await using var db = await contextFactory.CreateDbContextAsync();
        await db.Database.MigrateAsync();
    }
}
