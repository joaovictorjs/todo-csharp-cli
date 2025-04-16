using System.CommandLine;

namespace ToDo.App.Commands;

public class NewTaskCommand
{
    private static Option<string> _nameOption = new Option<string>(["-n", "--name"], "Task name")
    {
        IsRequired = true,
        ArgumentHelpName = "value",
    };
    private static Option<string> _descOption = new Option<string>(
        ["-d", "--desc"],
        "Task description"
    )
    {
        ArgumentHelpName = "value",
    };

    private static string _name = string.Empty;
    private static string _desc = string.Empty;

    public static Command Build()
    {
        var command = new Command("new", "Creates a new task") { _nameOption, _descOption };

        command.SetHandler(HandleNewTask, _nameOption, _descOption);

        return command;
    }

    private static void HandleNewTask(string name, string desc)
    {
        // throw new NotImplementedException();
    }
}
