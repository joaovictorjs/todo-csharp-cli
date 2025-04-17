using ToDo.Domain.Constants;
using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Extensions;
using ToDo.Domain.Interfaces;
using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.Domain.Validators;

public class TaskValidator(IRepository<TaskModel> repository) : ITaskValidator
{
    public async Task Validate(Operation operation, TaskModel task)
    {
        switch (operation)
        {
            case Operation.Create:
                {
                    await ValidateCreation(task);
                }
                break;
            case Operation.Update:
            case Operation.Delete:
                {
                    await ValidateDeletion(task);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
        }
    }

    private async Task ValidateDeletion(TaskModel task)
    {
        if ((await repository.ReadAsync(it => it.Id == task.Id)).Count == 0)
            throw new ValidationException(ExceptionMessages.TaskNotFound);
    }

    private async Task ValidateCreation(TaskModel task)
    {
        if (task.Name.IsNullOrWhiteSpace())
            throw new ValidationException(ExceptionMessages.EmptyName);

        if (await ValidateNameExists(task))
            throw new ValidationException(ExceptionMessages.NameInUse);
    }

    private async Task<bool> ValidateNameExists(TaskModel task)
    {
        return (await repository.ReadAsync(it => it.Name == task.Name)).Count != 0;
    }
}
