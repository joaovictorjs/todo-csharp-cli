namespace ToDo.Domain.Interfaces;

public interface ITaskService
{
    Task<bool> CreateAsync(Models.Task task);
}