using System.ComponentModel.DataAnnotations;
using ToDo.Domain.Enums;
using ToDo.Domain.Extensions;
using ToDo.Domain.Interfaces;
using Task = ToDo.Domain.Models.Task;

namespace ToDo.Domain.Validators;

public class TaskValidator(IRepository<Task> repository) : ITaskValidator
{
    public async System.Threading.Tasks.Task Validate(Operation operation, Task task)
    {
        switch (operation)
        {
            case Operation.Create:
            {
                await ValidateCreation(task);
            }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
        }
    }

    private async System.Threading.Tasks.Task ValidateCreation(Task task)
    {
        if (task.Name.IsNullOrWhiteSpace()) throw new ValidationException("Task name cannot be empty.");

        if (await ValidateNameExists(task)) throw new ValidationException("This name is already in use.");
    }

    private async Task<bool> ValidateNameExists(Task task)
    {
        return (await repository.ReadAsync(it => it.Name == task.Name)).Count != 0;
    }
}