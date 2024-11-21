using System.ComponentModel.DataAnnotations.Schema;

namespace MyTaskAPI.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Column("TaskID")]
        public int TaskId { get; set; }
        
        [Column("UserID")]
        public int UserId { get; set; }
        
        [Column("TaskName")]
        public string TaskName { get; set; }
        
        [Column("Description")]
        public string? Description { get; set; }
        
        [Column("IsImportant")]
        public bool IsImportant { get; set; }
        
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        
        [Column("DueDate")]
        public DateTime? DueDate { get; set; }
        
        [Column("IsCompleted")]
        public bool IsCompleted { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public ICollection<Step> Steps { get; set; }
    }
}
