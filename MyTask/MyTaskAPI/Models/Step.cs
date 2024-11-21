using System.ComponentModel.DataAnnotations.Schema;

namespace MyTaskAPI.Models
{
    [Table("Steps")]
    public class Step
    {
        [Column("StepID")]
        public int StepId { get; set; }
        
        [Column("TaskID")]
        public int TaskId { get; set; }
        
        [Column("StepNumber")]
        public int StepNumber { get; set; }
        
        [Column("StepName")]
        public string StepName { get; set; }
        
        [Column("IsCompleted")]
        public bool IsCompleted { get; set; }

        // Navigation Property
        public Task Task { get; set; }
    }
}
