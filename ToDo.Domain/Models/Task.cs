using System;
using ToDo.Domain.interfaces;

namespace ToDo.Domain.Models;

public class Task : IEntity
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool IsDone { get; set; }
}
