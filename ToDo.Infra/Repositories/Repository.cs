using System;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.interfaces;
using ToDo.Infra.Contexts;
using ToDo.Infra.Interfaces;

namespace ToDo.Infra.Repositories;

public class Repository<TEntity>(IDbContextFactory<SqliteContext> sqliteFactory)
    : IRepository<TEntity>
    where TEntity : IEntity { }
