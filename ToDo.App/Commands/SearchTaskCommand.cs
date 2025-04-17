using System.CommandLine;
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

    private void HandleSearchTasks(string? name, string? desc, bool? done, bool? noteDone)
    {
        throw new NotImplementedException();
    }
}
