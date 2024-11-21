using System.ComponentModel.DataAnnotations.Schema;

namespace MyTaskAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Column("UserID")]
        public int UserId { get; set; }
        
        [Column("Email")]
        public string Email { get; set; }
        
        [Column("FullName")]
        public string FullName { get; set; }
        
        [Column("Password")]
        public string Password { get; set; }
        
        [Column("Role")]
        public string Role { get; set; }

        // Navigation Property
        public ICollection<Task> Tasks { get; set; }
    }
}
