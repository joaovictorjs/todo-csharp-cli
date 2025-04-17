using Autofac;

namespace ToDo.App;

public class Injector
{
    private static Injector? _instance = null;
    public static Injector Instance => _instance ??= new Injector();
    private IContainer? _container = null;
    private ContainerBuilder _containerBuilder = new();

    private Injector()
    {
        _container = _containerBuilder.Build();
    }

    public T Resolve<T>() where T : notnull
    {
        ArgumentNullException.ThrowIfNull(_container);
        return _container.Resolve<T>();
    }
}