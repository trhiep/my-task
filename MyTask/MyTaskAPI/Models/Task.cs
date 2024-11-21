namespace MyTaskAPI.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public string TaskName { get; set; }
        public string? Description { get; set; }
        public bool IsImportant { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<Step> Steps { get; set; }
    }
}
