using System.ComponentModel.DataAnnotations;

namespace MyTaskAPI.Models.DTOs;

public class TaskCreateDto
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string? TaskName { get; set; }
    public string? Description { get; set; }
    public bool? IsImportant { get; set; }
    public DateTime? DueDate { get; set; }

    public ICollection<StepCreateDto>? Steps { get; set; }
}