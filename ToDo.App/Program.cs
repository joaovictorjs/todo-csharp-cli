using System.CommandLine;
using ToDo.App.Commands;

namespace ToDo.App;

public class Program
{
    public static void Main(string[] args)
    {
        var injector = Injector.Instance;
        
        var rootCommand = new RootCommand("CSharp ToDo list application");

        rootCommand.AddCommand(injector.Resolve<NewTaskCommand>().Build());

        rootCommand.Invoke(args);
    }
}