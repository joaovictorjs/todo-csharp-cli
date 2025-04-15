using System;

namespace ToDo.Domain.Models;

public class Task
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool IsDone { get; set; }
}
