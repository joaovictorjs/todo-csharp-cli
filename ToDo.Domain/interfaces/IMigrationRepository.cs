namespace ToDo.Domain.Interfaces;

public interface IMigrationRepository
{
    Task MigrateAsync();
}