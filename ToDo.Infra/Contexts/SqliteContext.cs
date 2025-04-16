using Microsoft.EntityFrameworkCore;

namespace ToDo.Infra.Contexts;

public class SqliteContext(DbContextOptions<SqliteContext> options) : DbContext(options)
{
}