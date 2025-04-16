using System;
using System.CommandLine;

namespace ToDo.App;

public class ProgramArgumentHandler
{
    public void Handle(string[] args)
    {
        var rootCommand = new RootCommand("CSharp todo list application");

        var createOption = new Option<string>(["-c", "--create"], "Creates a task")
        {
            ArgumentHelpName = "Task name",
        };

        var readOption = new Option<bool>(["-r", "--read"], "Lists all tasks");

        var updateOption = new Option<int>(
            ["-u", "--update"],
            "Updates the task with the given task ID"
        )
        {
            ArgumentHelpName = "Task ID",
        };

        var deleteOption = new Option<int>(
            ["-d", "--delete"],
            "Deletes the task with the given task ID"
        )
        {
            ArgumentHelpName = "Task ID",
        };

        rootCommand.AddOption(createOption);
        rootCommand.AddOption(readOption);
        rootCommand.AddOption(updateOption);
        rootCommand.AddOption(deleteOption);

        rootCommand.Invoke(args);
    }
}
