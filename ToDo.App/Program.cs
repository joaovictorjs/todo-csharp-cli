using System.CommandLine;

namespace ToDo.App;

public class Program
{
    public static void Main(string[] args)
    {
        var rootCommand = new RootCommand("CSharp ToDo list application");

        rootCommand.Invoke(args);
    }
}
