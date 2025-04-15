using System;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Infra.Contexts;

public class SqliteContextFactory : IDbContextFactory<SqliteContext>
{
    public SqliteContext CreateDbContext()
    {
        DbContextOptionsBuilder<SqliteContext> builder = new();
        builder.UseSqlite("Data Source=./todo.sqlite");
        return new SqliteContext(builder.Options);
    }
}
