using Microsoft.EntityFrameworkCore;
using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.Infra.Contexts;

public class SqliteContext(DbContextOptions<SqliteContext> options) : DbContext(options)
{
    public DbSet<TaskModel> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskModel>(entity => entity.HasIndex(t => t.Name).IsUnique());
    }
}
