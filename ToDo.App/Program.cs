using System.CommandLine;

namespace ToDo.App;

public class Program
{
    public static void Main(string[] args)
    {
        var argumentHandler = new ProgramArgumentHandler();
        argumentHandler.Handle(args);
    }
}
