using ToDo.Domain.Interfaces;

namespace ToDo.Domain.Models;

public class Task : IEntity
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool IsDone { get; set; }
}