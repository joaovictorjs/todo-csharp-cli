using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ToDo.Infra.Contexts;

public class SqliteContextDesignTimeFactory : IDesignTimeDbContextFactory<SqliteContext>
{
    public SqliteContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SqliteContext> builder = new();
        builder.UseSqlite("Data Source=./todo.sqlite");
        return new SqliteContext(builder.Options);
    }
}