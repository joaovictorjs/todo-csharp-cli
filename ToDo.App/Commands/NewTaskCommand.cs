using System.CommandLine;
using ToDo.Domain.Extensions;
using ToDo.Domain.Interfaces;
using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.App.Commands;

public class NewTaskCommand(ITaskService taskService)
{
    private readonly Option<string> _nameOption = new(["-n", "--name"], "Task name")
    {
        IsRequired = true,
        ArgumentHelpName = "value",
    };

    private readonly Option<string> _descOption = new(["-d", "--desc"], "Task description")
    {
        ArgumentHelpName = "value",
    };

    private string _name = string.Empty;
    private string _desc = string.Empty;

    public Command Build()
    {
        var command = new Command("new", "Creates a new task") { _nameOption, _descOption };

        command.SetHandler(HandleNewTask, _nameOption, _descOption);

        return command;
    }

    private async Task HandleNewTask(string name, string desc)
    {
       var result =  await taskService.CreateAsync(
            new TaskModel
            {
                Name = name,
                Description = desc.IsNullOrWhiteSpace() ? string.Empty : desc,
                IsDone = false,
            }
        );

        if (result)
            ConsoleExtensions.WriteSuccess("Task has been created.");
        else
            ConsoleExtensions.WriteError("Task has not been created.");
    }
}
