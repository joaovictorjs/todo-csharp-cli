using TaskMoldel = ToDo.Domain.Models.Task;

namespace ToDo.Domain.Interfaces;

public interface ITaskService
{
    Task<bool> CreateAsync(TaskMoldel task);
}