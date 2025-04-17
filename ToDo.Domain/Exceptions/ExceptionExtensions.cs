using System.Reflection.Metadata;

namespace ToDo.Domain.Exceptions;

public static class ExceptionExtensions
{
    public static void Handle(this Exception exception, Action<string> execute)
    {
        GlobalExceptionHandler.Handle(exception, execute);
    }
}