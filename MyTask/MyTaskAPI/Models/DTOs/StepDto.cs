namespace MyTaskAPI.Models.DTOs
{
    public class StepDto
    {
        public int? StepId { get; set; }
        public int? TaskId { get; set; }
        public int StepNumber { get; set; }
        public string StepName { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
