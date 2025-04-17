using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.Domain.Interfaces;

public interface ITaskService
{
    Task<bool> CreateAsync(TaskModel task);
    Task<List<TaskModel>> ReadAsync(string? name, string? description, bool? done);
    Task<bool> DeleteAsync(TaskModel task);
}