namespace MyTaskAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Navigation Property
        public ICollection<Task> Tasks { get; set; }
    }
}
