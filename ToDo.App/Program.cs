using System.CommandLine;
using ToDo.App.Commands;
using ToDo.Domain.Interfaces;

namespace ToDo.App;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var injector = Injector.Instance;
        await injector.Resolve<IMigrationRepository>().MigrateAsync();

        var rootCommand = new RootCommand("CSharp ToDo list application");

        rootCommand.AddCommand(injector.Resolve<NewTaskCommand>().Build());
        rootCommand.AddCommand(injector.Resolve<SearchTaskCommand>().Build());
        rootCommand.AddCommand(injector.Resolve<DeleteTaskCommand>().Build());

        return await rootCommand.InvokeAsync(args);
    }
}
