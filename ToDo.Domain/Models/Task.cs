using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Domain.Interfaces;

namespace ToDo.Domain.Models;

[Table("tasks")]
public class Task : IEntity
{
    [Column("id"), Key]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
    [Column("description")]
    public required string Description { get; set; }
    [Column("is_done")]
    public required bool IsDone { get; set; }
}