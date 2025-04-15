using System;
using Microsoft.EntityFrameworkCore;
using ToDo.Infra.Contexts;
using ToDo.Infra.Interfaces;

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
