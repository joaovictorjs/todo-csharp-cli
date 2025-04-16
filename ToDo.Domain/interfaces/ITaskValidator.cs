using ToDo.Domain.Enums;

namespace ToDo.Domain.Interfaces;

public interface ITaskValidator
{
    Task Validate(Operation operation, Models.Task task);
}