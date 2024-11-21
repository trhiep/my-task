using System.ComponentModel.DataAnnotations;

namespace MyTaskAPI.Models.DTOs;

public class StepCreateDto
{
    public int? TaskId { get; set; }
    
    [Required]
    public int StepNumber { get; set; }
    
    [Required]
    public string? StepName { get; set; }
}