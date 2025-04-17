using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;
using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.Infra.Services;

public class TaskService(IRepository<TaskModel> repository, ITaskValidator validator)
    : ITaskService
{
    public async Task<bool> CreateAsync(TaskModel task)
    {
        await validator.Validate(Operation.Create, task);
        return await repository.CreateAsync(task) > 0;
    }

    public Task<List<TaskModel>> ReadAsync(string? name, string? description, bool? done)
    {
        var filters = new List<Expression<Func<TaskModel, bool>>>();
        
        if (name is not null)
        {
            filters.Add(it => EF.Functions.Like(it.Name, name));
        }

        if (description is not null)
        {
            filters.Add(it => EF.Functions.Like(it.Description, description));
        }
        
        if (done is not null)
        {
            filters.Add(it => it.IsDone == done);
        }
        
        return repository.ReadAsync(filters.ToArray());
    }
}