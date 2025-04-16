namespace ToDo.Infra.Interfaces;

public interface IMigrationRepository
{
    Task MigrateAsync();
}