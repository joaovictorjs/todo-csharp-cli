using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Contexts;

namespace ToDo.Infra.Repositories;

public class MigrationRepository(IDbContextFactory<SqliteContext> sqliteFactory)
    : IMigrationRepository
{
    public async Task MigrateAsync()
    {
        await using var db = await sqliteFactory.CreateDbContextAsync();
        await db.Database.MigrateAsync();
    }
}