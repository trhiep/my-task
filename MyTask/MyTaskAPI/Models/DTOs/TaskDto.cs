namespace MyTaskAPI.Models.DTOs
{
    public class TaskDto
    {
        public int? TaskId { get; set; }
        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string? Description { get; set; }
        public bool? IsImportant { get; set; }
        public string? CreatedDate { get; set; }
        public string? DueDate { get; set; }
        public bool? IsCompleted { get; set; }

        public ICollection<StepDto>? Steps { get; set; }
    }
}
