using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;
using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.Infra.Services;

public class TaskService(IRepository<TaskModel> repository, ITaskValidator validator)
    : ITaskService
{
    public async Task<bool> CreateAsync(TaskModel task)
    {
        await validator.Validate(Operation.Create, task);
        return (await repository.CreateAsync(task)) > 0;
    }
}
