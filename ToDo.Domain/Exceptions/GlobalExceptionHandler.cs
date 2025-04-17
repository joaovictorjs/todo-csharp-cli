using System.Runtime.ExceptionServices;

namespace ToDo.Domain.Exceptions;

public static class GlobalExceptionHandler
{
    public static void Handle(Exception exception, Action<string> execute)
    {
        switch (exception)
        {
            case ValidationException validationException:
                execute(validationException.Message);
                break;

            default:
                ExceptionDispatchInfo.Capture(exception).Throw();
                break;
        }
    }
}
