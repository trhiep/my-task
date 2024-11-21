namespace MyTaskAPI.Models
{
    public class Step
    {
        public int StepID { get; set; }
        public int TaskID { get; set; }
        public int StepNumber { get; set; }
        public string StepName { get; set; }
        public bool IsCompleted { get; set; }

        // Navigation Property
        public Task Task { get; set; }
    }
}
