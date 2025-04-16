using System.ComponentModel.DataAnnotations;
using ToDo.Domain.Enums;
using ToDo.Domain.Extensions;
using ToDo.Domain.Interfaces;

namespace ToDo.Domain.Validators;

public class TaskValidator(IRepository<Models.Task> repository) : ITaskValidator
{
    public async Task Validate(Operation operation, Models.Task task)
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

    private async Task ValidateCreation(Models.Task task)
    {
        if (task.Name.IsNullOrWhiteSpace())
        {
            throw new ValidationException("Task name cannot be empty.");
        }
        
        if (await ValidateNameExists(task))
        {
            throw new ValidationException("This name is already in use.");
        }
    }

    private async Task<bool> ValidateNameExists(Models.Task task)
    {
        return (await repository.ReadAsync(it => it.Name == task.Name)).Count != 0;
    }
}
