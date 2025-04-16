using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.interfaces;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Contexts;

namespace ToDo.Infra.Repositories;

public class Repository<TEntity>(IDbContextFactory<SqliteContext> sqliteFactory)
    : IRepository<TEntity>
    where TEntity : class, IEntity
{
    public async Task<int> CreateAsync(TEntity entity)
    {
        await using var db = await sqliteFactory.CreateDbContextAsync();
        await db.Set<TEntity>().AddAsync(entity);
        return await db.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        await using var db = await sqliteFactory.CreateDbContextAsync();
        db.Set<TEntity>().Remove(entity);
        return await db.SaveChangesAsync();
    }

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> whereClause)
    {
        await using var db = await sqliteFactory.CreateDbContextAsync();
        return await db.Set<TEntity>().AsNoTracking().Where(whereClause).ToListAsync();
    }

    public async Task<int> UpdateAsync(TEntity entity)
    {
        await using var db = await sqliteFactory.CreateDbContextAsync();
        db.Set<TEntity>().Update(entity);
        return await db.SaveChangesAsync();
    }
}