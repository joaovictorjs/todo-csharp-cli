using System.CommandLine;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Interfaces;
using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.App.Commands;

public class DeleteTaskCommand(ITaskService taskService)
{
    private Option<int> _idOption = new(["--id", "-i"], "Id of the task to delete")
    {
        ArgumentHelpName = "value",
        IsRequired = true
    };

    public Command Build()
    {
        var command = new Command("delete", "Deletes a task"){_idOption};
        
        command.SetHandler(HandleDeleteTask, _idOption);
        
        return command;
    }

    private async Task HandleDeleteTask(int id)
    {
        try
        {
            var result = await taskService.DeleteAsync(new TaskModel
            {
                Id = id,
                Name = string.Empty,
                Description = string.Empty,
                IsDone = false
            });
            
            if(result)
                ConsoleExtensions.WriteSuccess("Task successfully deleted");
            else
                ConsoleExtensions.WriteError("Task could not be deleted");
        }
        catch (Exception ex)
        {
            ex.Handle(ConsoleExtensions.WriteError);
        }
    }
}
