using System.CommandLine;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Interfaces;

namespace ToDo.App.Commands;

public class SearchTaskCommand(ITaskService taskService)
{
    private readonly Option<string?> _nameOption = new(["-n", "--name"], "Filters the task name")
    {
        ArgumentHelpName = "value",
    };

    private readonly Option<string?> _descOption = new(
        ["-d", "--desc"],
        "Filters the task description"
    )
    {
        ArgumentHelpName = "value",
    };

    private readonly Option<bool?> _doneOption = new("--done", "Filters only tasks that are done");

    private readonly Option<bool?> _notDoneOption = new(
        "--not-done",
        "Filters only tasks that are not done"
    );

    public Command Build()
    {
        var command = new Command("search", "Searches tasks")
        {
            _nameOption,
            _descOption,
            _doneOption,
            _notDoneOption,
        };

        command.SetHandler(
            HandleSearchTasks,
            _nameOption,
            _descOption,
            _doneOption,
            _notDoneOption
        );

        return command;
    }

    private async Task HandleSearchTasks(string? name, string? desc, bool? done, bool? notDone)
    {
        try
        {
            var result = await taskService.ReadAsync(name, desc, done ?? !notDone);

            for (var i = 0; i < result.Count; i++)
            {
                if (i == 0)
                    Console.WriteLine();

                var task = result[i];

                Console.WriteLine(
                    $"Id: {task.Id}\nName: {task.Name}\nDescription: {task.Description}\nDone: {task.IsDone}\n"
                );

                if (i < result.Count - 1)
                    Console.WriteLine($"{new string('-', 44)}\n");
            }
        }
        catch (Exception ex)
        {
            ex.Handle(ConsoleExtensions.WriteError);
        }
    }
}
