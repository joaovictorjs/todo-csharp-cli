using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ToDo.App.Commands;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Validators;
using ToDo.Infra.Contexts;
using ToDo.Infra.Repositories;
using ToDo.Infra.Services;
using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.App;

public class Injector
{
    private static Injector? _instance = null;
    public static Injector Instance => _instance ??= new Injector();
    private IContainer? _container = null;
    private ContainerBuilder _builder = new();

    private Injector()
    {
        RegisterCommands();
        RegisterServices();
        RegisterRepositories();
        RegisterValidators();
        RegisterFactories();

        _container = _builder.Build();
    }

    private void RegisterFactories()
    {
        _builder
            .RegisterType<SqliteContextFactory>()
            .As<IDbContextFactory<SqliteContext>>()
            .SingleInstance();
    }

    private void RegisterValidators()
    {
        _builder.RegisterType<TaskValidator>().As<ITaskValidator>().SingleInstance();
    }

    private void RegisterRepositories()
    {
        _builder
            .RegisterType<Repository<TaskModel>>()
            .As<IRepository<TaskModel>>()
            .SingleInstance();

        _builder.RegisterType<MigrationRepository>().As<IMigrationRepository>();
    }

    private void RegisterServices()
    {
        _builder.RegisterType<TaskService>().As<ITaskService>().SingleInstance();
    }

    private void RegisterCommands()
    {
        _builder.RegisterType<NewTaskCommand>().SingleInstance();
        _builder.RegisterType<SearchTaskCommand>().SingleInstance();
        _builder.RegisterType<DeleteTaskCommand>().SingleInstance();
    }

    public T Resolve<T>()
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(_container);
        return _container.Resolve<T>();
    }
}
