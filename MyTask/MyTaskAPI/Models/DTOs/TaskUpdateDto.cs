using System.ComponentModel.DataAnnotations;

namespace MyTaskAPI.Models.DTOs;

public class TaskUpdateDto
{
    [Required]
    public int TaskId { get; set; }
    public string? TaskName { get; set; }
    public string? Description { get; set; }
    public bool? IsImportant { get; set; }
    public DateTime? DueDate { get; set; }
    public bool? IsCompleted { get; set; }
}