using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;

namespace ToDo.Domain.Validators;

public class TaskValidator(IRepository<Models.Task> repository) : ITaskValidator
{
    public Task Validate(Operation operation, Models.Task task)
    {
        throw new NotImplementedException();
    }
}